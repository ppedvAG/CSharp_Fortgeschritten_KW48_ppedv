using System;
using System.Threading;

namespace _010_Mutex_ProgramInstance
{
    internal class Program
    {
        static Mutex mutex;


        static void Main(string[] args)
        {
            if (Program.IsSingleInstaceNew())
            {
                Console.WriteLine("One Instance");
            }
            else
            {
                Console.WriteLine("More than one Instance");
            }

            Console.ReadLine();
        }


        //Läuft mein Programm nur einmal
        static bool IsSingleInstaceOld()
        {
            try
            {
                Mutex.OpenExisting("ABC");
            }
            catch
            {
                Program.mutex = new Mutex(true, "ABC");
                return true;
            }
            return false;
        }

        //Läuft mein Programm nur einmal
        static bool IsSingleInstaceNew()
        {
            if (Mutex.TryOpenExisting("ABC", out mutex))
            {
                
                return false;
            }
            else
            {
                mutex = new Mutex(false, "ABC");
                return true;
            }
                

            //return Mutex.TryOpenExisting("ABC", out mutex) ? false : true;  
        }
    }
}
