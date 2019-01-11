using System;
using System.Collections.Generic;
using System.Text;



namespace TeploService
{


    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            string SrvID = "";
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

            TeploService Srv = new TeploService();
            Srv.SrvID = SrvID;
            Srv.StartMe();
            ConsoleKeyInfo cki;
              // Prevent example from ending if CTL+C is pressed.
            Console.TreatControlCAsInput = true;

              do 
              {
                 cki = Console.ReadKey();
                 System.Threading.Thread.Sleep(100);  
               } while (cki.Key != ConsoleKey.Escape);          
           Srv.StopMe();
        }
    }
}