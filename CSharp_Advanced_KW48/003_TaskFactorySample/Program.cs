using System;
using System.Threading.Tasks;

namespace _003_TaskFactorySample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //.NET 4.0 
            Task task = Task.Factory.StartNew(MachEtwasInEinemThread); //Task wird sofort gestartet
            task.Wait();

            //.NET 4.5

            Task task2 = Task.Run(MachEtwasInEinemThread); //Intern wird Task.Factory.StartNew aufgerufen -> Task.Run dient lediglich als verkürzte Schreibweise.
            task2.Wait();

            Console.WriteLine("Bin fertig");
            Console.ReadLine();
        }


        private static void MachEtwasInEinemThread()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("#");
            }
        }
    }
}
