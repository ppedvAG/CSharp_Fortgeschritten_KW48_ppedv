using System;
using System.Threading;

namespace _004_ThreadWithParameterAndReturnValue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string retStr = string.Empty;
            string meinText = "Hello World";

            Thread thread = new Thread(() =>
            {

                //anonyme Methoden läuft im Thread un ruft StringToUpper auf 
                retStr = StringToUpper(meinText);
            });

            thread.Start();
            thread.Join();  

            Console.WriteLine(retStr);
            Console.ReadLine();
        }


        private static string StringToUpper(string param1)
        {
            return param1.ToUpper(); 
        }
    }
}
