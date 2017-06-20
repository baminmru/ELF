using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Diagnostics;
using LATIR2;


namespace STKService
{
    public class ThreadObj
     {
         public System.Data.DataRow dr;
         public TVMain.TVMain TvMain;
     }

    class DeviceProcessor
    {
        private System.Diagnostics.EventLog eventLog1;

        private void InitializeComponent()
        {
            this.eventLog1 = new System.Diagnostics.EventLog();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            // 
            // eventLog1
            // 
            this.eventLog1.Log = "Application";
            this.eventLog1.Source = "TeploSrv";
             ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();

        }
         public void Run()
        {
            InitializeComponent(); 
            //InfoReport("Starting DeviceThread...ID=" + DevID.ToString() );
            MainThread();
            //InfoReport("Stop DeviceThread...ID=" + DevID.ToString());
            Process.GetCurrentProcess().Kill();  
        }

        public string DevID="";
        public string SrvID = "";
     
        private TVMain.TVMain TvMain;
        private LATIR2.Manager Manager; 

        private void MainThread()
        {

          
            eventLog1.BeginInit();

            Manager = new LATIR2.Manager();
            System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
            System.Xml.XmlNode xn;
            xdoc.Load( System.IO.Path.GetDirectoryName(GetType().Assembly.Location) + "\\TeploSrvCfg.xml");
            xn = xdoc.LastChild;
            //site="teplo" user="supervisor" password="bami"
            Manager.Site = xn.Attributes.GetNamedItem("site").Value ;
            if (Manager.Session != null)
            {
                if (Manager.Session.Login(xn.Attributes.GetNamedItem("user").Value, xn.Attributes.GetNamedItem("password").Value))
                {
                    InfoReport("Login OK");
                }
                else
                {
                    ErrorReport("Login failed, try again... site=" + xn.Attributes.GetNamedItem("site").Value + " user =" + xn.Attributes.GetNamedItem("user").Value);
                    Manager = null;
                    return;
                }
            }
            else
            {
                ErrorReport("wrong site name. site=" + xn.Attributes.GetNamedItem("site").Value);
                Manager = null;
                return;
            }
 

            DataRow dr;
            bool bLogged = false;
            TvMain = new TVMain.TVMain();
            
            try
            {
            
                if (TvMain.Init(Manager,new Guid(SrvID)) == true)
                {
                    bLogged = true;
                }
                else
                {
                    WarningReport("Unable to login, check credentials");
                    return;
                }
            }
            catch (Exception Ex)
            {
            
               
            }
      
         
            System.Data.DataTable oRS;
            if (bLogged)
            {
                oRS = null;

                //oRS = Manager.Session.GetData("select TPLT_PLANCALL.*,TPLT_PLANCALL.dlastcall archtime from TPLT_PLANCALL    where TPLT_PLANCALL.INSTANCEID =" + Manager.Session.GetProvider().ID2Const(new Guid(DevID)) + "");
                //if (oRS != null)
                //{

                //    if (oRS.Rows.Count > 0)
                //    {
                //        try
                //        {
                //            dr = oRS.Rows[0];
                //            DeviceThread(dr, (DateTime)oRS.Rows[0]["ArchTime"],true);

                //        }
                //        catch (Exception Ex)
                //        {
                //            ErrorReport("Thread " + DevID.ToString() + " error:" + Ex.Message);
                //        }
                //    }
                //    oRS = null;

                //}



                oRS = Manager.Session.GetData("select TPLT_PLANCALL.* from TPLT_PLANCALL  where TPLT_PLANCALL.instanceid=" + Manager.Session.GetProvider().ID2Const(new Guid(DevID)) + "");
                if (oRS != null)
                {

                    if (oRS.Rows.Count > 0)
                    {
                        try
                        {
                            dr = oRS.Rows[0];
                            DeviceThread(dr,DateTime.Now,false );

                        }
                        catch (Exception Ex)
                        {
                            ErrorReport("Thread " + DevID.ToString() + " error:" + Ex.Message);
                        }
                    }
                    oRS = null;

                }

                try
                {
                   

                    dr = null;

                    // close transport library
                    TvMain.EndInit();
                    Manager.Session.Logout();
                    TvMain = null;
                    eventLog1.Dispose();
                    return;
                }
                catch (Exception Ex)
                {
                    ErrorReport("Closing DeviceThread error:" + Ex.Message);
                }
            }
            
            
        }
             
        private void DeviceThread( DataRow dr, DateTime ArchTime, Boolean UseArchTime)
        {

          
            DateTime SrvDate;
            Boolean DeviceOK ;
            Int16 archType_hour = 3;
            Int16 archType_day = 4;
            try
            {

                System.Guid TPLT_instanceid;
                bool chour = false, ccurr = false, c24 = false,csum = false;
                TPLT_instanceid = new Guid(DevID);//'new Guid(dr["instanceid"].ToString()) ;
                if (dr["chour"].ToString() != "0") chour = true;
                if (dr["ccurr"].ToString() != "0") ccurr = true;
                if (dr["c24"].ToString() != "0") c24 = true;
                if (dr["csum"].ToString() != "0") csum = true;

                System.Guid TPLC_instanceid;
                DataTable rs ;
                rs = Manager.Session.GetData("select  b2g(TPLC_HEADER.instanceid) did, TPLC_HEADER.* from TPLC_HEADER join TPLT_BDEVICES on TPLC_HEADER.ID_BD=TPLT_BDEVICES.TPLT_BDEVICESID where TPLT_BDEVICES.instanceid=" + Manager.Session.GetProvider().ID2Const(TPLT_instanceid) + "");
                TPLC_instanceid=new Guid(rs.Rows[0]["did"].ToString()) ;

                SrvDate = DateTime.Now;
                try
                {
                    SrvDate = Manager.Session.GetServerTime();
                }
                catch { 
                }

                
                if (chour || ccurr || c24 || csum)
                {
            
                    if (TvMain.DeviceInit(TPLT_instanceid))  //NextPort + 1
                    {
                        DeviceOK = true;
                     
                    }
                    else
                    {
                        TvMain.WriteErrToDB( DateTime.Now, "Ошибка инициализации протокола");
                        DeviceOK = false;
                    }

                    if (DeviceOK)
                    {
                        TvMain.connect();
                        if (TvMain.isConnected()==false )
                        {
                            TvMain.WriteErrToDB( DateTime.Now, "Ошибка соединения с тепловычислителем");
                            ErrorReport("CounterID "+ DevID +" Counter initialization Error!");
                            DeviceOK = false;
                        }
                    }
                    if (DeviceOK)
                    {

                       
                        DateTime ddd;
                        ddd = SrvDate;
                        try
                        {
                            if (UseArchTime)
                                ddd = ArchTime;
                            else
                                ddd = Convert.ToDateTime(dr["dnexthour"].ToString());
                        }
                        catch
                        {

                        }
                        if (chour && ddd <= SrvDate)
                        {
                           
                            //DateTime dlasthour, nowhour,tempdate;
                            DateTime tempdate;
                            Int16 numhour;
                            numhour = Convert.ToInt16("0" + dr["numhour"].ToString());
                            //if (TvMain.LockDevice(TPLT_instanceid, 5 * numhour))
                            if(true)
                            {

                                InfoReport("Thread " + TPLT_instanceid.ToString() + " read hour archive at " + SrvDate.ToString());
                                if (ddd.AddHours(numhour) <= SrvDate.AddMinutes(35))
                                {

                                    //dlasthour = Convert.ToDateTime(dr["dlasthour"].ToString());
                                    tempdate = ddd;
                                    tempdate = tempdate.AddHours(-1);

                                    for (int j = 0; j <= numhour - 1; j++)
                                    {
                                        
                                        try
                                        {
                                            TvMain.HoldLine();
                                            tempdate = tempdate.AddHours(1);
                                            //transaction = TvMain.dbconnect.BeginTransaction(IsolationLevel.ReadCommitted)

                                            String str="";
                                            //TvMain.ClearDBarch(DateTimePickerAfter.Value, DateTimePickerBefor.Value, archType_hour, ListBox1.SelectedItem("ID_BD").ToString)
                                            Console.WriteLine("read hour " + tempdate.ToString() );
                                            if (TvMain.isConnected())
                                            {
                                                str = TvMain.readarch(archType_hour, tempdate.Year, tempdate.Month, tempdate.Day, tempdate.Hour);
                                            }
                                            //InfoReport("readarch->" + str );

                                            if (str.Length == 0)
                                            {
                                                //transaction.Rollback()
                                                WarningReport("CounterID: " + DevID + " hour archive: " + str + tempdate.ToString());

                                            }
                                            else
                                            {

                                                if (str.Substring(0, 6) != "Ошибка")
                                                {
                                                    if (TvMain.CheckForArch(TVMain.TVMain.enumArchType.H , tempdate.Year, tempdate.Month, tempdate.Day, tempdate.Hour, TPLC_instanceid) == false)
                                                    {
                                                        if (TvMain.isConnected())
                                                        {

                                                            if (TvMain.TVD.isArchToDBWrite)
                                                            {
                                                                TvMain.ClearDBarch(tempdate.AddSeconds(-1), tempdate.AddSeconds(+1), TVMain.TVMain.enumArchType.H, TPLC_instanceid);
                                                                //InfoReport("CounterID " + TPLT_instanceid.ToString() + " -> " + 
                                                                TvMain.WriteArchToDB();
                                                                //);
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    //transaction.Rollback()
                                                    WarningReport("CounterID: " + DevID + " hour archive: " + str + tempdate.ToString());

                                                }
                                            }

                                        }
                                        catch (Exception Ex)
                                        {
                                            //transaction.Rollback()
                                            ErrorReport("CounterID " + DevID + " hour archive failed, " + Ex.Message);
                                        }
                                 
                                 
                                    }//for (int j = 0;j <= razn.Hours + razn.Days * 24;j++)


                                    if (TvMain.isConnected())
                                    {

                                        TvMain.SetTimeToPlanCall(TPLT_instanceid, "dnexthour", ddd.AddHours(numhour));
                                        tempdate = new DateTime(ddd.Year, ddd.Month, ddd.Day, ddd.Hour, 0, 0);
                                        TvMain.SetTimeToPlanCall(TPLT_instanceid, "dlasthour", tempdate.AddSeconds(-1));
                                    }
                                
                                }
                                else
                                {


                                    //dlasthour = Convert.ToDateTime(dr["dlasthour"].ToString());
                                    tempdate = ddd;
                                    tempdate = tempdate.AddHours(1);

                                    for (int j = 0; j <= numhour - 1; j++)
                                    {
                                        try
                                        {
                                            TvMain.HoldLine();
                                            tempdate = tempdate.AddHours(-1);
                                            //transaction = TvMain.dbconnect.BeginTransaction(IsolationLevel.ReadCommitted)
                                            Console.WriteLine("read hour " + tempdate.ToString());
                                            String str="";
                                            //TvMain.ClearDBarch(DateTimePickerAfter.Value, DateTimePickerBefor.Value, archType_hour, ListBox1.SelectedItem("ID_BD").ToString)
                                            if (TvMain.isConnected())
                                            {

                                                str = TvMain.readarch(archType_hour, tempdate.Year, tempdate.Month, tempdate.Day, tempdate.Hour);
                                            }
                                            if (str.Length == 0)
                                            {
                                                //transaction.Rollback()
                                                WarningReport("CounterID: "+ DevID +" " + str + tempdate.ToString());

                                            }
                                            else
                                            {
                                                if (str.Substring(0, 6) != "Ошибка")
                                                {
                                                    if (TvMain.CheckForArch(TVMain.TVMain.enumArchType.H, tempdate.Year, tempdate.Month, tempdate.Day, tempdate.Hour, TPLC_instanceid) == false)
                                                    {
                                                        if (TvMain.isConnected())
                                                        {

                                                            if (TvMain.TVD.isArchToDBWrite)
                                                            {

                                                                TvMain.ClearDBarch(tempdate.AddSeconds(-1), tempdate.AddSeconds(+1), TVMain.TVMain.enumArchType.H, TPLC_instanceid);
                                                                //InfoReport("CounterID " + TPLT_instanceid.ToString() + " -> " + 
                                                                TvMain.WriteArchToDB();
                                                                //);
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    //transaction.Rollback()
                                                    WarningReport("CounterID: " + DevID + " hour archive: " + str + tempdate.ToString());

                                                }
                                            }

                                        }
                                        catch (Exception Ex)
                                        {
                                            //transaction.Rollback()
                                            ErrorReport("CounterID " + DevID + " hour archive failed, " + Ex.Message);
                                        }
                                    }//for (int j = 0;j <= razn.Hours + razn.Days * 24;j++)

                                    if (TvMain.isConnected())
                                    {

                                        TvMain.SetTimeToPlanCall(TPLT_instanceid, "dnexthour", ddd.AddMinutes(Convert.ToDouble(dr["icall"].ToString())));
                                        tempdate = new DateTime(ddd.Year, ddd.Month, ddd.Day, ddd.Hour, 0, 0);
                                        TvMain.SetTimeToPlanCall(TPLT_instanceid, "dlasthour", tempdate.AddSeconds(-1));
                                    }
                               
                                }
                                //TvMain.UnLockDevice(TPLT_instanceid); 
                            } // Lock
                           
                        }//if (chour)


                        ddd = SrvDate;
                        try
                        {
                            if (UseArchTime)
                                ddd = ArchTime;
                            else
                                ddd = Convert.ToDateTime(dr["dnext24"].ToString());
                        }
                        catch
                        {

                        }

                        if (c24 && ddd <= SrvDate)
                        {


                            InfoReport("Thread " + TPLT_instanceid.ToString() + " read day archive at " + SrvDate.ToString());
                            DateTime tempdate;
                            Int16 num24;
                            num24 = Convert.ToInt16(dr["num24"].ToString());

                            if (ddd.AddDays(num24) <= SrvDate.AddDays(1))
                            {

                                tempdate = ddd;
                                tempdate = tempdate.AddDays(-1);
                                try
                                {
                                    TvMain.HoldLine();
                                    //if( TvMain.LockDevice(TPLT_instanceid,5 * num24 )){ 
                                    if(true){
                                    for (int j = 0; j <= num24 - 1; j++)
                                    {

                                        tempdate = tempdate.AddDays(1);
                                        //transaction = TvMain.dbconnect.BeginTransaction(IsolationLevel.ReadCommitted)

                                        String str="";
                                        //TvMain.ClearDBarch(DateTimePickerAfter.Value, DateTimePickerBefor.Value, archType_hour, ListBox1.SelectedItem("ID_BD").ToString)
                                        Console.WriteLine("read day " + tempdate.ToString());
                                        if (TvMain.isConnected())
                                        {

                                            str = TvMain.readarch(archType_day, tempdate.Year, tempdate.Month, tempdate.Day, tempdate.Hour);
                                        }
                                        if (str.Length == 0)
                                        {
                                            //transaction.Rollback()
                                            WarningReport("CounterID: "+ DevID +" " + str + tempdate.ToString());

                                        }
                                        else
                                        {
                                            if (str.Substring(0, 6) != "Ошибка")
                                            {
                                                if (TvMain.CheckForArch(TVMain.TVMain.enumArchType.D, tempdate.Year, tempdate.Month, tempdate.Day, 0, TPLC_instanceid) == false)
                                                {
                                                    if (TvMain.isConnected())
                                                    {

                                                        if (TvMain.TVD.isArchToDBWrite)
                                                        {
                                                            //TvMain.ClearDBArchString(archType_day, tempdate.Year, tempdate.Month, tempdate.Day, 0, TPLT_instanceid);
                                                            TvMain.ClearDBarch(tempdate.AddSeconds(-1), tempdate.AddSeconds(+1), TVMain.TVMain.enumArchType.D, TPLC_instanceid);
                                                            //InfoReport("CounterID " + TPLT_instanceid.ToString() + " -> " + 
                                                            TvMain.WriteArchToDB();
                                                            //);
                                                        }
                                                    }
                                                }
                                                //TvMain.SetTimeToPlanCall(TPLT_instanceid.ToString(), "dnext24", ddd.AddHours(Convert.ToDouble(dr["icall24"].ToString())));
                                                if (TvMain.isConnected())
                                                {

                                                    TvMain.SetTimeToPlanCall(TPLT_instanceid, "dnext24", ddd.AddDays(num24));
                                                    tempdate = new DateTime(ddd.Year, ddd.Month, ddd.Day, 0, 0, 0);
                                                    TvMain.SetTimeToPlanCall(TPLT_instanceid, "dlastday", tempdate.AddSeconds(-1));
                                                }
                                            }
                                            else
                                            {
                                                WarningReport("CounterID:  " + DevID + " day archive: " + str + tempdate.ToString());
                                            }
                                        }

                                    }//for (int j = 0; j <= razn.Days; j++)
                                         //TvMain.UnLockDevice(TPLT_instanceid); 
                                    }
                                }//try
                                catch (Exception Ex)
                                {
                                    //transaction.Rollback()
                                    ErrorReport("CounterID: "+ DevID +" read day arch failed, " + Ex.Message);
                                }

                            }
                            else
                            {
                                tempdate = ddd;
                                tempdate = tempdate.AddDays(1);
                                try
                                {
                                    //if( TvMain.LockDevice(TPLT_instanceid,5 * num24) ){ 
                                    if(true){
                                    for (int j = 0; j <= num24 - 1; j++)
                                    {

                                        tempdate = tempdate.AddDays(-1);
                                        //transaction = TvMain.dbconnect.BeginTransaction(IsolationLevel.ReadCommitted)
                                        Console.WriteLine("read day " + tempdate.ToString());
                                        TvMain.HoldLine();

                                        String str="";
                                        //TvMain.ClearDBarch(DateTimePickerAfter.Value, DateTimePickerBefor.Value, archType_hour, ListBox1.SelectedItem("ID_BD").ToString)
                                        if (TvMain.isConnected())
                                        {

                                            str = TvMain.readarch(archType_day, tempdate.Year, tempdate.Month, tempdate.Day, tempdate.Hour);
                                        }
                                        if (str.Length == 0)
                                        {
                                            //transaction.Rollback()
                                            WarningReport("CounterID: " + DevID + " day archive: " + str + tempdate.ToString());

                                        }
                                        else
                                        {
                                            if (str.Substring(0, 6) != "Ошибка")
                                            {
                                                if (TvMain.CheckForArch(TVMain.TVMain.enumArchType.D, tempdate.Year, tempdate.Month, tempdate.Day, 0, TPLC_instanceid) == false)
                                                {
                                                    if (TvMain.isConnected())
                                                    {

                                                        if (TvMain.TVD.isArchToDBWrite)
                                                        {
                                                            //TvMain.ClearDBArchString(archType_day, tempdate.Year, tempdate.Month, tempdate.Day, 0, TPLT_instanceid);
                                                            TvMain.ClearDBarch(tempdate.AddSeconds(-1), tempdate.AddSeconds(+1), TVMain.TVMain.enumArchType.D, TPLC_instanceid);
                                                            //InfoReport("CounterID " + TPLT_instanceid.ToString() + " -> " + 
                                                            TvMain.WriteArchToDB();
                                                            //);
                                                        }
                                                    }
                                                }
                                                if (TvMain.isConnected())
                                                {

                                                    TvMain.SetTimeToPlanCall(TPLT_instanceid, "dnext24", ddd.AddHours(Convert.ToDouble(dr["icall24"].ToString())));
                                                    tempdate = new DateTime(ddd.Year, ddd.Month, ddd.Day, 0, 0, 0);
                                                    TvMain.SetTimeToPlanCall(TPLT_instanceid, "dlastday", tempdate.AddSeconds(-1));
                                                }
                                            }
                                            else
                                            {
                                                WarningReport("CounterID: " + DevID + " day archive: " + str + tempdate.ToString());
                                            }
                                        }

                                    }//for (int j = 0; j <= razn.Days; j++)
                                    //TvMain.UnLockDevice(TPLT_instanceid );
                                    }
                                }//try
                                catch (Exception Ex)
                                {
                                    //transaction.Rollback()
                                    ErrorReport("CounterID: "+ DevID +" read day arch failed, " + Ex.Message);
                                }
                            }
                        }//if (c24)

                        if (ccurr)

                            ddd = SrvDate;
                        try
                        {
                            if (UseArchTime)
                                ddd = ArchTime;
                            else
                                ddd = Convert.ToDateTime(dr["dnextcurr"].ToString());
                        }
                        catch
                        {

                        }


                        if (ccurr && ddd <= SrvDate)
                        {
                            DateTime tempdate;
                            Double nmin;
                            InfoReport("Thread " + TPLT_instanceid.ToString() + " read current data at " + ddd.ToString());
                            try
                            {
                                //if(TvMain.LockDevice(TPLT_instanceid,5)){
                                TvMain.HoldLine();
                                if(true){
                                String str="";
                              
                                if (TvMain.isConnected())
                                {

                                    str = TvMain.readmarch();
                                }
                                //InfoReport("CounterID " + TPLT_instanceid.ToString() + " -> " +str);
                                if (str.Length == 0)
                                {

                                    TvMain.WriteErrToDB( SrvDate, "Ошибка чтения мгновенного архива");
                                }
                                else
                                {
                                    if (str.Substring(0, 6) != "Ошибка")
                                    {
                                        //InfoReport("CounterID " + TPLT_instanceid.ToString() + " -> " + 
                                        if (TvMain.isConnected())
                                        {

                                            if (TvMain.TVD.isMArchToDBWrite)
                                            {
                                                TvMain.WritemArchToDB();
                                            }
                                        }
                                        //);
                                        tempdate = ddd;
                                        nmin = Convert.ToDouble(dr["icallcurr"].ToString());

                                        while (tempdate.AddMinutes(nmin) <= SrvDate)
                                        {
                                            tempdate = tempdate.AddMinutes(nmin);
                                        }
                                        tempdate = tempdate.AddMinutes(nmin);

                                        if (TvMain.isConnected())
                                        {

                                            TvMain.SetTimeToPlanCall(TPLT_instanceid, "dnextcurr", tempdate);
                                        }
                                    }
                                    else {
                                        TvMain.WriteErrToDB( SrvDate, str);
                                    }
                                }
                                //TvMain.UnLockDevice(TPLT_instanceid);
                            }
                            }//try
                            catch (Exception Ex)
                            {
                                TvMain.WriteErrToDB( SrvDate, "Ошибка чтения мгновенного архива:" + Ex.Message);  
                                ErrorReport("CounterID "+ DevID +" read current arch failed, " + Ex.Message);
                            }
                          
                        }//if (ccurr)


                        if (csum)

                            ddd = SrvDate;
                        try
                        {
                            if (UseArchTime)
                                ddd = ArchTime;
                            else
                                ddd = Convert.ToDateTime(dr["dnextsum"].ToString());
                        }
                        catch
                        {

                        }


                        if (csum && ddd <= SrvDate)
                        {
                            DateTime tempdate;
                            Double nmin;
                            InfoReport("Thread " + TPLT_instanceid.ToString() + " read total data at " + SrvDate.ToString());
                            try
                            {

                                String str="";
                                //if (TvMain.LockDevice(TPLT_instanceid, 5))
                                if(true)
                                {
                                    TvMain.HoldLine();
                                    if (TvMain.isConnected())
                                    {

                                        str = TvMain.readtarch();
                                    }
                                    InfoReport("CounterID " + TPLT_instanceid.ToString() + " -> " + str);
                                    if (str.Length == 0)
                                    {
                                        // oops!

                                    }
                                    else
                                    {
                                        if (str.Substring(0, 6) != "Ошибка")
                                        {
                                            //InfoReport("CounterID " + TPLT_instanceid.ToString() + " -> " + 
                                            if (TvMain.isConnected())
                                            {

                                                if (TvMain.TVD.isTArchToDBWrite)
                                                {
                                                    TvMain.WriteTArchToDB();
                                                }
                                            }
                                            //);
                                            tempdate = ddd;
                                            nmin = Convert.ToDouble(dr["icallsum"].ToString());

                                            while (tempdate.AddMinutes(nmin) <= SrvDate)
                                            {
                                                tempdate = tempdate.AddMinutes(nmin);
                                            }
                                            tempdate = tempdate.AddMinutes(nmin);
                                            if (TvMain.isConnected())
                                            {

                                                TvMain.SetTimeToPlanCall(TPLT_instanceid, "dnextsum", tempdate);
                                            }
                                        }
                                    }
                                    //TvMain.UnLockDevice(TPLT_instanceid);
                                }
                            }//try
                            catch (Exception Ex)
                            {
                                ErrorReport("CounterID "+ DevID +" read total arch failed, " + Ex.Message);
                            }
                        }//if (ccurr)

                        // finalization 

                        TvMain.SetTimeToPlanCall(TPLT_instanceid, "dlastcall", SrvDate);

    
                    }
                    else
                    {
                        ErrorReport("CounterID "+ DevID +" Transport level initialization Error! "  );
                    }
                }
                else
                {
                    InfoReport("CounterID "+ DevID +" plan is active, but no tasks to process!");
                }
            }
            catch (System.Exception threadEx)
            {
                ErrorReport("CounterID "+ DevID +" thread failed, " + threadEx.Message);
            }
        }

        #region log functions
        private Object thisLock = new Object();
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
            }catch{
            }

            Console.WriteLine(ELET.ToString() + " :" + Message);
          
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

      
    }

    
}
