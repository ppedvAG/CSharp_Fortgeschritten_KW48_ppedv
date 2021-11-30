using System;
using System.Threading;

namespace _001_ThreadStarten
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            
            //System.Threading;
            Thread thread = new Thread(MachEtwasInEinemThread); //Parameter ist der Funktionszeiger der Methode MachEtwasInEinemThread
            thread.Start();

            thread.Join(); //Warten bis die Methode: MachEtwasInEinemThread fertig ist
            
            for (int i = 0; i < 100; i++)
                Console.WriteLine("*");

            Console.ReadLine();
        }

        private static void MachEtwasInEinemThread()
        {
            for(int i = 0; i < 100; i++)
                Console.WriteLine("#");
        }
    }
}
