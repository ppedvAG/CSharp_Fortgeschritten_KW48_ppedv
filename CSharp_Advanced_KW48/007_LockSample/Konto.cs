using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _007_LockSample
{
    public static class Konto
    {
        public static decimal Kontostand { get; set; } = 0;
        public static int TransactionId { get; set; } = 0;

        //Diese Variable wird beim dem Keyword: lock als Flag verwendet. Es signalisiert einen ankommenden Thread, ob der Bereich zugänglich ist
        //oder ob der Bereich schon von einem anderen Thread verwendet wird.

        //Bereich wird gemeint, in dem die Variablen manipuliert. 
        public static object lockObject = new object();

        public static void Einzahlen(decimal betrag)
        {
            try
            {
                //Zweiter Thread muss quasi hier warten 
                lock (lockObject)
                {
                    //Hier wird nur ein Thread arbeiten können
                    TransactionId++;

                    Kontostand += betrag;

                    Console.WriteLine($"Id:{TransactionId} \t Kontostand nach dem Einzahlen: {Kontostand}");
                }
            }
            catch(Exception ex)
            {

            }
        }

        public static void Abheben(decimal betrag)
        {
            try
            {
                //Zweiter Thread muss quasi hier warten 
                lock (lockObject)
                {
                    //Hier wird nur ein Thread arbeiten können
                    TransactionId++;

                    Kontostand -= betrag;

                    Console.WriteLine($"Id:{TransactionId} \t Kontostand nach dem Abhebem: {Kontostand}");
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
