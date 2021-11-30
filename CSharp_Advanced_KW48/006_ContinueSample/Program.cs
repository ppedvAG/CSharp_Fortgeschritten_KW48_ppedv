using System;
using System.Threading;
using System.Threading.Tasks;

namespace _006_ContinueSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task t1 = new Task(() =>
            {
                Console.WriteLine("Task 1 ist gestartet");
                Thread.Sleep(1000);
                
                throw new Exception();
            });

            t1.Start();

            //t1.Wait(); //Callback wenn Task fertig durchgelaufen ist
            
            //Allgemeiner Folgetask (Wird immer ausgeführt) 
            t1.ContinueWith(t1 => AllgemerinFolgetask());

            //Bei Fehler
            t1.ContinueWith(t1 => FolgetaskBeiFehler(), TaskContinuationOptions.OnlyOnFaulted);

            //Be Erfolg 
            t1.ContinueWith(t1=>FolgetaskBeiErfolg(), TaskContinuationOptions.OnlyOnRanToCompletion);

            Console.ReadLine();
        }

        private static void AllgemerinFolgetask()
        {
            Console.WriteLine("Allgemerin Folgetask");
        }

        private static void FolgetaskBeiFehler()
        {
            Console.WriteLine("FolgetaskBeiFehler");
        }

        private static void FolgetaskBeiErfolg()
        {
            Console.WriteLine("FolgetaskBeiErfolg");
        }

        
    }
}
