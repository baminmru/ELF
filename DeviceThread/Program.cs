using System.Collections.Generic;
using System.Text;

namespace STKService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {

            // The Length property provides the number of array elements
            //System.Console.WriteLine("parameter count = {0}", args.Length);
            string DevID = "";
            bool NextD=false ;
            string SrvID = "";
            bool NextS = false;
            for (int i = 0; i < args.Length; i++)
            {
                //System.Console.WriteLine("Arg[{0}] = [{1}]", i, args[i]);
                if (NextD==true){
                    NextD=false;
                    DevID = args[i];
                }

                if (args[i].ToLower() == "-d")
                {
                    NextD = true;
                }

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

            if (DevID == "") return;
             
            DeviceProcessor Srv = new DeviceProcessor();
            Srv.DevID = DevID;
            Srv.SrvID = SrvID;
            Srv.Run();
            Srv = null; 
        }
    }
}