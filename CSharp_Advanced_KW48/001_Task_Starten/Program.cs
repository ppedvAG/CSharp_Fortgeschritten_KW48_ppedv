using System;
using System.Threading.Tasks; //.NET 4.0 

namespace _001_Task_Starten
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task easyTask = new Task(MachEtwasInEinemThread);
            easyTask.Start();

            easyTask.Wait(); //Callback wird von Start zurückgegeben 

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("*");
            }

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
