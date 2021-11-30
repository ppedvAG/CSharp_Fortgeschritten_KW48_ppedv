using System;
using System.Threading;
using System.Threading.Tasks;

namespace _002_Task_Bennden
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource(); //ab NET 4.0 

            Task easyTask = new Task(MeineMethideMitAbbrechen, cts);
            easyTask.Start();

            Thread.Sleep(5000);
            cts.Cancel();
            Console.WriteLine("Bin fertig, weiter zu Beispiel 2 with KeyPress");
            Console.ReadKey();

            CancellationTokenSource cts1 = new CancellationTokenSource();
            Task secondTask = new Task(MeineMethideMitAbbrechenWithCancellationToken, cts1.Token);
            secondTask.Start();

            Thread.Sleep(5000);
            cts1.Cancel();

            Console.WriteLine("Bin fertig");
            Console.ReadLine();
        }


        private static void MeineMethideMitAbbrechen(object param)
        {
            CancellationTokenSource source = (CancellationTokenSource)param;

            while (true)
            {
                Console.WriteLine("zzzzZZZZZzzzzZZZZZzz");
                Thread.Sleep(50);

                if (source.IsCancellationRequested)
                    break;

            }
        }


        private static void MeineMethideMitAbbrechenWithCancellationToken(object param)
        {
            CancellationToken source = (CancellationToken)param;

            while (true)
            {
                Console.WriteLine("zzzzZZZZZzzzzZZZZZzz");
                Thread.Sleep(50);

                if (source.IsCancellationRequested)
                    break;

            }
        }
    }
}
