using System;
using System.Threading;
using System.Threading.Tasks;

namespace TPL1_Lab
{
    class Program
    {
        #region Solution
        static void Main(string[] args)
        {
            /* TPL Übung mit CancelationTokenSource
             * In dieser Aufgabe soll die Methode ShowPrimeNumbers eine Möglichkeit bekommen, dass man 
             * den Primzahlen Algorithmus von aussen beenden kann. 
             * 
             * Der Primzahlalgorithmus soll nach 20 Sekunden automatisch von der Main-Methode beendet werden 
             */
            CancellationTokenSource cts = new CancellationTokenSource();
            
            Task easyTask = new Task(ShowPrimeNumbers, cts.Token);
            easyTask.Start();

            Thread.Sleep(20000);
            cts.Cancel();


            Console.WriteLine("20 Sekunden sind vorbei");
            Console.ReadLine();
        }

        public static void ShowPrimeNumbers(object param)
        {
            CancellationToken cancellationToken = (CancellationToken)param;
            long i = 0;

            while (true)
            {
                i++;
                if (chkprime(i))
                {
                    Console.WriteLine(i.ToString());
                }

                if (cancellationToken.IsCancellationRequested)
                    break;
            }
        }

        private static bool chkprime(long num)
        {
            for (long i = 2; i < num; i++)
                if (num % i == 0)
                    return false;
            return true;
        }
        #endregion Solution
    }


}
