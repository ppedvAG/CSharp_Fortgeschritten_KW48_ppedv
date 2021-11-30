using System;
using System.Threading;

namespace _008_MonitorSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static void KritischerCodeAbschnitt()
        {
            int x = 1; //x muss auf 1 gesetzt werden 

            Monitor.Enter(x);

            try
            {
                //Mache etwas
            }
            finally
            {
                Monitor.Exit(x);
            }

        }
    }
}
