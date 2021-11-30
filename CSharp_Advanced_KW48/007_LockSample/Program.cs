
using System;
using System.Threading;

namespace _007_LockSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 500; i++)
            {
                //schortcut: STRG + "Punkt" -> bietet das Namespace des jeweiligen Objectes als using an 
                ThreadPool.QueueUserWorkItem(MachEinKontoUpdate);
            }
            Console.WriteLine("fertig");
            Console.ReadLine();
        }


        private static void MachEinKontoUpdate(object state)
        {
            Random rnd = new Random();

            for (int i = 0; i < 5000; i++)
            {
                int auswahl = rnd.Next();

                if (auswahl % 2 == 0)
                {
                    Konto.Einzahlen(rnd.Next(0, 1000));
                }
                else
                {
                    Konto.Abheben(rnd.Next(0, 1000));

                }
            }
        }

        
    }
}
