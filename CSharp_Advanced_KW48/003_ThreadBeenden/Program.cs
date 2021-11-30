using System;
using System.Threading;

namespace _003_ThreadBeenden
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(MachEtwas);
            thread.Start();


            //Hauptprogramm wartet 3 Sekunden und beendet, danaach die Methode MachEtwas() 
            Thread.Sleep(3000);

            
            thread.Interrupt();

            Console.WriteLine("Ready");
            Console.ReadLine();
        }

        private static void MachEtwas()
        {
            try
            {
                //10 Sekunden dauert diese Schleife
                for (int i = 0; i < 50; i++)
                {

                    Console.WriteLine("zzzZZZzzzZZZzzzZZ");
                    Thread.Sleep(200);
                }
            }
            catch
            {

            }
        }
    }
}
