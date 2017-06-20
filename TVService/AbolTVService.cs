using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using TVMain;


namespace AbolTVService
{
    public partial class AbolTVService : ServiceBase
    {
        public class ThreadObj
        {
            public Guid DevID;
            public DateTime StartTime;
            public System.Diagnostics.Process Process;
            public string TransportType;
        }

        public ManualResetEvent pStopServiceEvent;
        public ManualResetEvent pStopApprovedEvent;

        private Dictionary<Guid, ThreadObj> Threads;
        private System.Threading.Thread pMainThread = null;

        private const int cWaitInterval = 120000;
        private Object thisLock = new Object();
        //private LogInfo pLogParams = new LogInfo();

        Guid id_bd;
        public AbolTVService()
        {
            InitializeComponent();
            pStopServiceEvent = new ManualResetEvent(false);
            pStopApprovedEvent = new ManualResetEvent(false);
        }

        public void StartMe()
        {
            string[] Args = new string[1];
            Args[0] = "test";
            OnStart(Args);
        }

        public void StopMe()
        {
            OnStop();
        }

        public string SrvID = Guid.Empty.ToString();

        protected override void OnStart(string[] args)
        {
            Threads = new Dictionary<Guid, ThreadObj>();




            bool NextS = false;
            for (int i = 0; i < args.Length; i++)
            {

                if (NextS == true)
                {
                    NextS = false;
                    SrvID = args[i];
                }

                if (args[i].ToLower() == "-s")
                {
                    NextS = true;
                }
            }


            InfoReport("Starting AbolTVService...");





            if (pMainThread == null)
            {
                InfoReport("Creating AbolTVService main thread...");
                pMainThread = new Thread(new ThreadStart(MainThread));
                //pMainThread.ApartmentState = ApartmentState.MTA;
                pMainThread.SetApartmentState(ApartmentState.MTA);
                pMainThread.Name = "AbolTVService Main thread! It's need for AbolTVService's working";
            }
            InfoReport("Starting AbolTVService main thread...");
            pMainThread.Start();
            //base.OnStart(args); 
        }
        private void StopDeviceThreads()
        {
            foreach (ThreadObj to in Threads.Values)
            {
                try
                {
                    if (!to.Process.HasExited) to.Process.Kill();
                }
                catch { }
            }
        }
        private LATIR2.Manager Manager;
        private LATIR2.Session Session;
        private void MainThread()
        {
            Threads = new Dictionary<Guid, ThreadObj>();
            eventLog1.BeginInit();
            DataRow dr;
            int RequestInterval = 60000;
            //Manager = new LATIR2.Manager();


            bool bLogged = false;
            do
            {
                bLogged = false;

                do
                {
                    // случилось команда на выход из сервиса
                    if (pStopServiceEvent.WaitOne(1, false))
                    {
                        try
                        {

                            InfoReport("Exiting working thread...");
                            StopDeviceThreads();
                            pStopApprovedEvent.Set();
                            return;
                        }
                        catch (Exception Ex)
                        {
                            ErrorReport("Exiting working thread error: " + Ex.Message);
                            return;
                        }
                    }



                    // пытаемся соединиться с базой данных
                    try
                    {

                        InfoReport("Try DB login.");
                        Manager = new LATIR2.Manager();
                        System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
                        System.Xml.XmlNode xn;
                        xdoc.Load(System.IO.Path.GetDirectoryName(GetType().Assembly.Location) + "\\TeploSrvCfg.xml");
                        xn = xdoc.LastChild;
                        //site="teplo" user="supervisor" password="bami"
                        Manager.Site = xn.Attributes.GetNamedItem("site").Value;
                        Session = Manager.Session;

                        if (Manager.Session.Login(xn.Attributes.GetNamedItem("user").Value, xn.Attributes.GetNamedItem("password").Value))
                        {
                            InfoReport("Login OK");
                            bLogged = true;
                        }
                        else
                        {
                            ErrorReport("Login failed, try again... site=" + xn.Attributes.GetNamedItem("site").Value + " user =" + xn.Attributes.GetNamedItem("user").Value);
                            bLogged = false;
                        }
                    }
                    catch (Exception Ex)
                    {
                        //pRefService.ErrorReport("Login failed, try again... " + Ex.Message);
                        ErrorReport("Login failed, try again... " + Ex.Message);

                    }
                } while (!pStopServiceEvent.WaitOne(1000, false) && !bLogged);

                //pRefService.InfoReport("DB Initialization OK");
                InfoReport("DB Initialization OK");


                // соединение прошло успешно
                if (bLogged)
                {

                    System.Data.DataTable oRS;
                    ThreadObj throbj = null;
                    TVMain.TVMain tv = null;


                    tv = new TVMain.TVMain();

                    tv.Init(Manager, new Guid(SrvID));



                    // pass 1 modem transport
                    oRS = null;
                    int ModemCnt = 0;


                    oRS = Manager.Session.GetData("SELECT COUNT(*) CNT FROM TPSRV_INFO JOIN TPSRV_MODEMS  ON TPSRV_INFO.InstanceID=TPSRV_MODEMS.InstanceID AND UsedUntil<" + Manager.Session.GetProvider().GetServerDate() + " and IsUsable =-1 AND TPSRV_INFOid=" + Manager.Session.GetProvider().ID2Const(new Guid(SrvID)) + "");
                    if (oRS != null)
                    {

                        if (oRS.Rows.Count > 0)
                        {
                            ModemCnt = Convert.ToInt32(oRS.Rows[0][0]);
                        }
                    }


                    //// call TPQ records first

                    //if (ModemCnt > 0)
                    //{


                    //    oRS = Manager.Session.GetData("select b2g(tplt_bdevices.instanceid) devid,  tplt_plancall.*, " + Manager.Session.GetProvider().GetServerDate() + " ServerDate " +
                    //     " from tplt_bdevices join  tplt_plancall  " +
                    //     " on tplt_bdevices.instanceid=tplt_plancall.instanceid  " +
                    //     "  where " +
                    //     " TPLT_bdevices.instanceid in (  select instanceid from TPLT_CONNECT where connecttype =" + Manager.Session.GetProvider().ID2Const(new Guid("0FB5D884-526F-43C5-9E6B-3E48C0D58A46")) + " and ConnectionEnabled=-1 ) and " +
                    //     " ((tplt_plancall.chour=-1 )  " +
                    //     " or (tplt_plancall.ccurr=-1 )  " +
                    //     " or (tplt_plancall.c24=-1 )   " +
                    //     " or (tplt_plancall.csum=-1 ))" +
                    //     " order by tplt_plancall.dlastcall");





                    //    if (oRS != null)
                    //    {

                    //        if (oRS.Rows.Count > 0)
                    //        {
                    //            InfoReport("Checking " + oRS.Rows.Count + " active plan(s) at " + DateTime.Now.ToString());
                    //            for (int i = 0; i < ModemCnt && i < oRS.Rows.Count; i++)
                    //            {

                    //                try
                    //                {
                    //                    Random rand = new Random();
                    //                    int rrr;
                    //                    rrr = rand.Next(oRS.Rows.Count);
                    //                    //rrr = i;
                    //                    dr = oRS.Rows[rrr];
                    //                    id_bd = new Guid(dr["devid"].ToString());

                    //                    if (!Threads.ContainsKey(id_bd))
                    //                    {

                    //                        // создаем и стартуем новый процесс для опроса устройства
                    //                        throbj = new ThreadObj();
                    //                        throbj.DevID = id_bd;
                    //                        throbj.StartTime = DateTime.Now;
                    //                        Process p = new Process();
                    //                        String FileName;
                    //                        FileName = System.IO.Path.GetDirectoryName(this.GetType().Assembly.Location) + "\\DeviceThread.exe";
                    //                        String DirName = System.IO.Path.GetDirectoryName(this.GetType().Assembly.Location);
                    //                        p.StartInfo.FileName = FileName;
                    //                        p.StartInfo.Arguments = "-S " + SrvID + " -D " + id_bd.ToString();
                    //                        p.StartInfo.WorkingDirectory = DirName;
                    //                        throbj.Process = p;
                    //                        throbj.TransportType = tv.GetTransportType(id_bd);
                    //                        Threads.Add(id_bd, throbj);
                    //                        throbj.Process.Start();
                    //                        Thread.Sleep(2000); 
                    //                    }
                    //                    else
                    //                    {
                    //                        if (Threads[id_bd].Process != null)
                    //                        {

                    //                            if (Threads[id_bd].Process.HasExited == true)
                    //                            {
                    //                                // инициализируем процесс еще раз
                    //                                try
                    //                                {
                    //                                    Threads[id_bd].Process.Close();
                    //                                    Threads[id_bd].Process = null;
                    //                                }
                    //                                catch
                    //                                {
                    //                                    Threads[id_bd].Process = null;
                    //                                }
                    //                                throbj = new ThreadObj();
                    //                                throbj.DevID = id_bd;
                    //                                Process p = new Process();
                    //                                String FileName;
                    //                                FileName = System.IO.Path.GetDirectoryName(this.GetType().Assembly.Location) + "\\DeviceThread.exe";
                    //                                String DirName = System.IO.Path.GetDirectoryName(this.GetType().Assembly.Location);

                    //                                p.StartInfo.FileName = FileName;
                    //                                p.StartInfo.Arguments = "-S " + SrvID + " -D " + id_bd.ToString();
                    //                                p.StartInfo.WorkingDirectory = DirName;
                    //                                throbj.Process = p;
                    //                                throbj.TransportType = tv.GetTransportType(id_bd);
                    //                                Threads[id_bd] = throbj;
                    //                                throbj.Process.Start();
                    //                                Thread.Sleep(2000);

                    //                            }
                    //                            else
                    //                            {
                    //                                //process still working
                    //                                if (Threads[id_bd].StartTime.AddMinutes(10) < DateTime.Now)
                    //                                {

                    //                                    if (Threads[id_bd].TransportType == "NPORT")
                    //                                    {
                    //                                        Threads[id_bd].Process.Kill();
                    //                                        Threads.Remove(id_bd);
                    //                                    }
                    //                                }

                    //                            }
                    //                        }
                    //                        else
                    //                        {
                    //                            throbj = new ThreadObj();
                    //                            throbj.DevID = id_bd;
                    //                            Process p = new Process();
                    //                            String FileName;
                    //                            FileName = System.IO.Path.GetDirectoryName(this.GetType().Assembly.Location) + "\\DeviceThread.exe";
                    //                            String DirName = System.IO.Path.GetDirectoryName(this.GetType().Assembly.Location);

                    //                            p.StartInfo.FileName = FileName;
                    //                            p.StartInfo.Arguments = "-S " + SrvID + " -D " + id_bd.ToString();
                    //                            p.StartInfo.WorkingDirectory = DirName;
                    //                            throbj.Process = p;
                    //                            Threads[id_bd] = throbj;
                    //                            throbj.Process.Start();
                    //                            Thread.Sleep(2000);
                    //                        }
                    //                    }

                    //                }
                    //                catch (Exception Ex)
                    //                {
                    //                    ErrorReport("Thread " + id_bd.ToString() + " error:" + Ex.Message);
                    //                }
                    //            }
                    //        } // зершение цикла по активным устройствам 

                    //        oRS = null;
                    //        throbj = null;

                    //    }
                    //} // Modem count



                    //{ // non modem connected nodes


                    //      oRS = Manager.Session.GetData("select b2g(tplt_bdevices.instanceid) devid,  tplt_plancall.*, " + Manager.Session.GetProvider().GetServerDate() +" ServerDate " +
                    //         " from tplt_bdevices join  tplt_plancall  " +
                    //         " on tplt_bdevices.instanceid=tplt_plancall.instanceid  " +
                    //         "  where " +
                    //         " TPLT_bdevices.instanceid in (  select instanceid from TPLT_CONNECT where connecttype <>" + Manager.Session.GetProvider().ID2Const(new Guid("0FB5D884-526F-43C5-9E6B-3E48C0D58A46")) + " and ConnectionEnabled=-1 ) and " +
                    //         " ((tplt_plancall.chour=-1 )  " +
                    //         " or (tplt_plancall.ccurr=-1 )  " +
                    //         " or (tplt_plancall.c24=-1 )   " +
                    //         " or (tplt_plancall.csum=-1 ))" +
                    //         " order by tplt_plancall.dlastcall");


                    //    if (oRS != null)
                    //    {

                    //        if (oRS.Rows.Count > 0)
                    //        {
                    //            InfoReport("Checking " + oRS.Rows.Count + " active plan(s) at " + DateTime.Now.ToString());
                    //            for (int i = 0; i < 3 && i < oRS.Rows.Count; i++)
                    //            {

                    //                try
                    //                {
                    //                    Random rand = new Random();
                    //                    int rrr;
                    //                    rrr = rand.Next(oRS.Rows.Count);
                    //                    //rrr = i;
                    //                    dr = oRS.Rows[rrr];
                    //                    id_bd = new Guid(dr["devid"].ToString());

                    //                    if (!Threads.ContainsKey(id_bd))
                    //                    {

                    //                        // создаем и стартуем новый процесс для опроса устройства
                    //                        throbj = new ThreadObj();
                    //                        throbj.DevID = id_bd;
                    //                        throbj.StartTime = DateTime.Now;
                    //                        Process p = new Process();
                    //                        String FileName;
                    //                        FileName = System.IO.Path.GetDirectoryName(this.GetType().Assembly.Location) + "\\DeviceThread.exe";
                    //                        String DirName = System.IO.Path.GetDirectoryName(this.GetType().Assembly.Location);
                    //                        p.StartInfo.FileName = FileName;
                    //                        p.StartInfo.Arguments = "-S " + SrvID + " -D " + id_bd.ToString();
                    //                        p.StartInfo.WorkingDirectory = DirName;
                    //                        throbj.Process = p;
                    //                        throbj.TransportType = tv.GetTransportType(id_bd);
                    //                        Threads.Add(id_bd, throbj);
                    //                        throbj.Process.Start();
                    //                        Thread.Sleep(2000);
                    //                    }
                    //                    else
                    //                    {
                    //                        if (Threads[id_bd].Process != null)
                    //                        {

                    //                            if (Threads[id_bd].Process.HasExited == true)
                    //                            {
                    //                                // инициализируем процесс еще раз
                    //                                try
                    //                                {
                    //                                    Threads[id_bd].Process.Close();
                    //                                    Threads[id_bd].Process = null;
                    //                                }
                    //                                catch
                    //                                {
                    //                                    Threads[id_bd].Process = null;
                    //                                }
                    //                                throbj = new ThreadObj();
                    //                                throbj.DevID = id_bd;
                    //                                Process p = new Process();
                    //                                String FileName;
                    //                                FileName = System.IO.Path.GetDirectoryName(this.GetType().Assembly.Location) + "\\DeviceThread.exe";
                    //                                String DirName = System.IO.Path.GetDirectoryName(this.GetType().Assembly.Location);

                    //                                p.StartInfo.FileName = FileName;
                    //                                p.StartInfo.Arguments = "-S " + SrvID + " -D " + id_bd.ToString();
                    //                                p.StartInfo.WorkingDirectory = DirName;
                    //                                throbj.Process = p;
                    //                                throbj.TransportType = tv.GetTransportType(id_bd);
                    //                                Threads[id_bd] = throbj;
                    //                                throbj.Process.Start();
                    //                                Thread.Sleep(2000);

                    //                            }
                    //                            else
                    //                            {
                    //                                //process still working
                    //                                if (Threads[id_bd].StartTime.AddMinutes(10) < DateTime.Now)
                    //                                {

                    //                                    if (Threads[id_bd].TransportType == "NPORT")
                    //                                    {
                    //                                        Threads[id_bd].Process.Kill();
                    //                                        Threads.Remove(id_bd);
                    //                                    }
                    //                                }

                    //                            }
                    //                        }
                    //                        else
                    //                        {
                    //                            throbj = new ThreadObj();
                    //                            throbj.DevID = id_bd;
                    //                            Process p = new Process();
                    //                            String FileName;
                    //                            FileName = System.IO.Path.GetDirectoryName(this.GetType().Assembly.Location) + "\\DeviceThread.exe";
                    //                            String DirName = System.IO.Path.GetDirectoryName(this.GetType().Assembly.Location);

                    //                            p.StartInfo.FileName = FileName;
                    //                            p.StartInfo.Arguments = "-S " + SrvID + " -D " + id_bd.ToString();
                    //                            p.StartInfo.WorkingDirectory = DirName;
                    //                            throbj.Process = p;
                    //                            Threads[id_bd] = throbj;
                    //                            throbj.Process.Start();
                    //                            Thread.Sleep(2000);
                    //                        }
                    //                    }

                    //                }
                    //                catch (Exception Ex)
                    //                {
                    //                    ErrorReport("Thread " + id_bd.ToString() + " error:" + Ex.Message);
                    //                }
                    //            }
                    //        } // зершение цикла по активным устройствам 

                    //        oRS = null;
                    //        throbj = null;

                    //    }
                    //}





                    // call TPLT_PLANCALL later

                    if (ModemCnt > 0)
                    {
                        oRS = Manager.Session.GetData("select  b2g(tplt_plancall.instanceid) did, tplt_plancall.*, " + Manager.Session.GetProvider().GetServerDate() + " ServerDate " +
                             " from tplt_bdevices join tplt_plancall  " +
                             " on TPLT_bdevices.instanceid=tplt_plancall.instanceid  " +
                             " where    " +
                             " TPLT_bdevices.instanceid in (  select instanceid from TPLT_CONNECT where connecttype=" + Manager.Session.GetProvider().ID2Const(new Guid("0FB5D884-526F-43C5-9E6B-3E48C0D58A46")) + " and ConnectionEnabled=-1 ) and " +
                             " ((tplt_plancall.chour=-1 and " + Manager.Session.GetProvider().IsNUll("tplt_plancall.DNEXTHOUR", Manager.Session.GetProvider().GetServerDate() + "-1") + "<=" + Manager.Session.GetProvider().GetServerDate() + ")  " +
                             " or (tplt_plancall.ccurr=-1 and " + Manager.Session.GetProvider().IsNUll("tplt_plancall.dnextcurr", Manager.Session.GetProvider().GetServerDate() + "-1") + " <=" + Manager.Session.GetProvider().GetServerDate() + ")  " +
                             " or (tplt_plancall.c24=-1 and " + Manager.Session.GetProvider().IsNUll("tplt_plancall.dnext24", Manager.Session.GetProvider().GetServerDate() + "-1") + "<=" + Manager.Session.GetProvider().GetServerDate() + ")   " +
                             " or (tplt_plancall.csum=-1 and " + Manager.Session.GetProvider().IsNUll("tplt_plancall.dnextsum", Manager.Session.GetProvider().GetServerDate() + "-1") + "<=" + Manager.Session.GetProvider().GetServerDate() + "))" +
                             " order by tplt_plancall.dnextcurr");


                        if (oRS != null)
                        {

                            if (oRS.Rows.Count > 0)
                            {
                                InfoReport("Checking " + oRS.Rows.Count + " active plan(s) at " + DateTime.Now.ToString());
                                for (int i = 0; i < ModemCnt && i < oRS.Rows.Count; i++)
                                {

                                    try
                                    {
                                        Random rand = new Random();
                                        int rrr;
                                        rrr = rand.Next(oRS.Rows.Count);
                                        //rrr = i;
                                        dr = oRS.Rows[rrr];
                                        id_bd = new Guid(dr["did"].ToString());

                                        if (!Threads.ContainsKey(id_bd))
                                        {

                                            // создаем и стартуем новый процесс для опроса устройства
                                            throbj = new ThreadObj();
                                            throbj.DevID = id_bd;
                                            throbj.StartTime = DateTime.Now;
                                            Process p = new Process();
                                            String FileName;
                                            FileName = System.IO.Path.GetDirectoryName(this.GetType().Assembly.Location) + "\\DeviceThread.exe";
                                            String DirName = System.IO.Path.GetDirectoryName(this.GetType().Assembly.Location);
                                            p.StartInfo.FileName = FileName;
                                            p.StartInfo.Arguments = "-S " + SrvID + " -D " + id_bd.ToString();
                                            p.StartInfo.WorkingDirectory = DirName;
                                            throbj.Process = p;
                                            throbj.TransportType = tv.GetTransportType(id_bd);
                                            Threads.Add(id_bd, throbj);
                                            throbj.Process.Start();
                                            Thread.Sleep(2000);
                                        }
                                        else
                                        {
                                            if (Threads[id_bd].Process != null)
                                            {

                                                if (Threads[id_bd].Process.HasExited == true)
                                                {
                                                    // инициализируем процесс еще раз
                                                    try
                                                    {
                                                        Threads[id_bd].Process.Close();
                                                        Threads[id_bd].Process = null;
                                                    }
                                                    catch
                                                    {
                                                        Threads[id_bd].Process = null;
                                                    }
                                                    throbj = new ThreadObj();
                                                    throbj.DevID = id_bd;
                                                    Process p = new Process();
                                                    String FileName;
                                                    FileName = System.IO.Path.GetDirectoryName(this.GetType().Assembly.Location) + "\\DeviceThread.exe";
                                                    String DirName = System.IO.Path.GetDirectoryName(this.GetType().Assembly.Location);

                                                    p.StartInfo.FileName = FileName;
                                                    p.StartInfo.Arguments = "-S " + SrvID + " -D " + id_bd.ToString();
                                                    p.StartInfo.WorkingDirectory = DirName;
                                                    throbj.Process = p;
                                                    throbj.TransportType = tv.GetTransportType(id_bd);
                                                    Threads[id_bd] = throbj;
                                                    throbj.Process.Start();
                                                    Thread.Sleep(2000);

                                                }
                                                else
                                                {
                                                    //process still working
                                                    if (Threads[id_bd].StartTime.AddMinutes(10) < DateTime.Now)
                                                    {

                                                        if (Threads[id_bd].TransportType == "NPORT")
                                                        {
                                                            Threads[id_bd].Process.Kill();
                                                            Threads.Remove(id_bd);
                                                        }
                                                    }

                                                }
                                            }
                                            else
                                            {
                                                throbj = new ThreadObj();
                                                throbj.DevID = id_bd;
                                                Process p = new Process();
                                                String FileName;
                                                FileName = System.IO.Path.GetDirectoryName(this.GetType().Assembly.Location) + "\\DeviceThread.exe";
                                                String DirName = System.IO.Path.GetDirectoryName(this.GetType().Assembly.Location);

                                                p.StartInfo.FileName = FileName;
                                                p.StartInfo.Arguments = "-S " + SrvID + " -D " + id_bd.ToString();
                                                p.StartInfo.WorkingDirectory = DirName;
                                                throbj.Process = p;
                                                Threads[id_bd] = throbj;
                                                throbj.Process.Start();
                                                Thread.Sleep(2000);
                                            }
                                        }

                                    }
                                    catch (Exception Ex)
                                    {
                                        ErrorReport("Thread " + id_bd.ToString() + " error:" + Ex.Message);
                                    }
                                }
                            } // зершение цикла по активным устройствам 

                            oRS = null;
                            throbj = null;

                        }
                    }



                    {
                        oRS = Manager.Session.GetData("select b2g(tplt_plancall.instanceid) did,  tplt_plancall.*, " + Manager.Session.GetProvider().GetServerDate() + " ServerDate " +
                             " from tplt_bdevices join tplt_plancall  " +
                             " on TPLT_bdevices.instanceid=tplt_plancall.instanceid  " +
                             " where    " +
                             " TPLT_bdevices.instanceid in (  select instanceid from TPLT_CONNECT where connecttype <> " + Manager.Session.GetProvider().ID2Const(new Guid("0FB5D884-526F-43C5-9E6B-3E48C0D58A46")) + " and ConnectionEnabled=-1 ) and " +
                             " ((tplt_plancall.chour=-1 and " + Manager.Session.GetProvider().IsNUll("tplt_plancall.DNEXTHOUR", Manager.Session.GetProvider().GetServerDate() + "-1") + "<=" + Manager.Session.GetProvider().GetServerDate() + ")  " +
                             " or (tplt_plancall.ccurr=-1 and " + Manager.Session.GetProvider().IsNUll("tplt_plancall.dnextcurr", Manager.Session.GetProvider().GetServerDate() + "-1") + " <=" + Manager.Session.GetProvider().GetServerDate() + ")  " +
                             " or (tplt_plancall.c24=-1 and " + Manager.Session.GetProvider().IsNUll("tplt_plancall.dnext24", Manager.Session.GetProvider().GetServerDate() + "-1") + "<=" + Manager.Session.GetProvider().GetServerDate() + ")   " +
                             " or (tplt_plancall.csum=-1 and " + Manager.Session.GetProvider().IsNUll("tplt_plancall.dnextsum", Manager.Session.GetProvider().GetServerDate() + "-1") + "<=" + Manager.Session.GetProvider().GetServerDate() + "))" +
                             " order by tplt_plancall.dnextcurr");


                        if (oRS != null)
                        {

                            if (oRS.Rows.Count > 0)
                            {
                                InfoReport("Checking " + oRS.Rows.Count + " active plan(s) at " + DateTime.Now.ToString());
                                for (int i = 0; i < 3 && i < oRS.Rows.Count; i++)
                                {

                                    try
                                    {
                                        Random rand = new Random();
                                        int rrr;
                                        rrr = rand.Next(oRS.Rows.Count);
                                        //rrr = i;
                                        dr = oRS.Rows[rrr];
                                        id_bd = new Guid(dr["did"].ToString());

                                        if (!Threads.ContainsKey(id_bd))
                                        {

                                            // создаем и стартуем новый процесс для опроса устройства
                                            throbj = new ThreadObj();
                                            throbj.DevID = id_bd;
                                            throbj.StartTime = DateTime.Now;
                                            Process p = new Process();
                                            String FileName;
                                            FileName = System.IO.Path.GetDirectoryName(this.GetType().Assembly.Location) + "\\DeviceThread.exe";
                                            String DirName = System.IO.Path.GetDirectoryName(this.GetType().Assembly.Location);
                                            p.StartInfo.FileName = FileName;
                                            p.StartInfo.Arguments = "-S " + SrvID + " -D " + id_bd.ToString();
                                            p.StartInfo.WorkingDirectory = DirName;
                                            throbj.Process = p;
                                            throbj.TransportType = tv.GetTransportType(id_bd);
                                            Threads.Add(id_bd, throbj);
                                            throbj.Process.Start();
                                            Thread.Sleep(2000);
                                        }
                                        else
                                        {
                                            if (Threads[id_bd].Process != null)
                                            {

                                                if (Threads[id_bd].Process.HasExited == true)
                                                {
                                                    // инициализируем процесс еще раз
                                                    try
                                                    {
                                                        Threads[id_bd].Process.Close();
                                                        Threads[id_bd].Process = null;
                                                    }
                                                    catch
                                                    {
                                                        Threads[id_bd].Process = null;
                                                    }
                                                    throbj = new ThreadObj();
                                                    throbj.DevID = id_bd;
                                                    Process p = new Process();
                                                    String FileName;
                                                    FileName = System.IO.Path.GetDirectoryName(this.GetType().Assembly.Location) + "\\DeviceThread.exe";
                                                    String DirName = System.IO.Path.GetDirectoryName(this.GetType().Assembly.Location);

                                                    p.StartInfo.FileName = FileName;
                                                    p.StartInfo.Arguments = "-S " + SrvID + " -D " + id_bd.ToString();
                                                    p.StartInfo.WorkingDirectory = DirName;
                                                    throbj.Process = p;
                                                    throbj.TransportType = tv.GetTransportType(id_bd);
                                                    Threads[id_bd] = throbj;
                                                    throbj.Process.Start();
                                                    Thread.Sleep(2000);

                                                }
                                                else
                                                {
                                                    //process still working
                                                    if (Threads[id_bd].StartTime.AddMinutes(10) < DateTime.Now)
                                                    {

                                                        if (Threads[id_bd].TransportType == "NPORT")
                                                        {
                                                            Threads[id_bd].Process.Kill();
                                                            Threads.Remove(id_bd);
                                                        }
                                                    }

                                                }
                                            }
                                            else
                                            {
                                                throbj = new ThreadObj();
                                                throbj.DevID = id_bd;
                                                Process p = new Process();
                                                String FileName;
                                                FileName = System.IO.Path.GetDirectoryName(this.GetType().Assembly.Location) + "\\DeviceThread.exe";
                                                String DirName = System.IO.Path.GetDirectoryName(this.GetType().Assembly.Location);

                                                p.StartInfo.FileName = FileName;
                                                p.StartInfo.Arguments = "-S " + SrvID + " -D " + id_bd.ToString();
                                                p.StartInfo.WorkingDirectory = DirName;
                                                throbj.Process = p;
                                                Threads[id_bd] = throbj;
                                                throbj.Process.Start();
                                                Thread.Sleep(2000);
                                            }
                                        }

                                    }
                                    catch (Exception Ex)
                                    {
                                        ErrorReport("Thread " + id_bd.ToString() + " error:" + Ex.Message);
                                    }
                                }
                            } // зершение цикла по активным устройствам 

                            oRS = null;
                            throbj = null;

                        }
                    }

                    tv.EndInit();
                    tv = null;
                }
                Manager.Session.Logout();
                Manager = null;


            } while (!pStopServiceEvent.WaitOne(RequestInterval, false));

            try
            {
                InfoReport("Closing AbolTVService...");
                StopDeviceThreads();
                Threads.Clear();
                Threads = null;
                dr = null;
                //base.OnStop();
                eventLog1.Dispose();
                return;
            }
            catch (Exception Ex)
            {
                ErrorReport("Closing AbolTVService error:" + Ex.Message);
            }


        }


        protected override void OnStop()
        {
            pStopServiceEvent.Set();
        }
        protected override void OnContinue()
        {
            base.OnContinue();

        }

        protected override void OnPause()
        {
            base.OnPause();

        }



        #region log functions
        public void ErrorReport(string Message)
        {
            lock (thisLock)
            {
                LogReport(Message, EventLogEntryType.Error);
            }
            Debug.Print(Message);
        }
        public void InfoReport(string Message)
        {
            lock (thisLock)
            {
                LogReport(Message, EventLogEntryType.Information);
            }
            Debug.Print(Message);
        }
        public void WarningReport(string Message)
        {
            lock (thisLock)
            {
                LogReport(Message, EventLogEntryType.Warning);
            }
            Debug.Print(Message);
        }
        public void LogReport(string Message, System.Diagnostics.EventLogEntryType ELET)
        {
            try
            {
                this.eventLog1.WriteEntry(Message, ELET);
                System.Diagnostics.Trace.WriteLine(ELET.ToString() + " :" + Message);
            }
            catch
            {
            }

            try
            {
                string FileName = "";//string FileName = pLogParams.LogFile;
                if (FileName == string.Empty || FileName == "") FileName = System.IO.Path.GetDirectoryName(GetType().Assembly.Location) + "\\TEPLOSrvLog.txt";
                System.IO.TextWriter LogFile = new System.IO.StreamWriter(FileName, true);
                if (ELET == System.Diagnostics.EventLogEntryType.Error)
                    LogFile.WriteLine(System.DateTime.Now.ToString() + " Error: " + Message);
                else if (ELET == System.Diagnostics.EventLogEntryType.Warning)
                    LogFile.WriteLine(System.DateTime.Now.ToString() + " Warning: " + Message);
                else
                    LogFile.WriteLine(System.DateTime.Now.ToString() + Message);
                LogFile.Close();
                LogFile = null;
            }
            catch { }
            return;
        }
        #endregion log functions

        private void eventLog1_EntryWritten(object sender, EntryWrittenEventArgs e)
        {

        }
    }
}
