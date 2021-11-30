using System;
using System.Threading;

namespace _002_ThreadMitParameterStarten
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ParameterizedThreadStart parameterized = new ParameterizedThreadStart(MachEtwasInEinemThread);

            Thread t = new Thread(parameterized);
            t.Start(600);

            t.Join();

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("*");
            }


            Console.ReadLine();
        }



        private static void MachEtwasInEinemThread(object obj)
        {
            if (obj is int until)
            {
                for (int i= 0; i <until; i++)
                    Console.WriteLine("#");
            }
        }
    }
}
