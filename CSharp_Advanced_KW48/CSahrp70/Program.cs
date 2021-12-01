using System;

namespace CSahrp70
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Out -Referenz
            string eingabe = "12345";
            int zahl;

            if (int.TryParse(eingabe, out zahl)) //Ich verwende int als Referenz 
            {
                Console.WriteLine(zahl);
            }

            int zahl2;
            if (MyTryParse(eingabe, out zahl2))
            {
                Console.WriteLine(zahl2);
            }
            #endregion


            #region Tupel & Deconstruct 
            string name = "Muster";
            string vorname = "Alf";
            int alter1 = 20;

            // Aus mehreren Variablen initialisieren wir ein Object

            //Variablen werden im Konstruktor den Member Variablen zugewiesen
            Person p = new Person(vorname, name, alter1);

            var tupelRückgabe = p.TupelAusgabePeron();

            Console.WriteLine(tupelRückgabe.Vorname);
            Console.WriteLine(tupelRückgabe.Name);
            Console.WriteLine(tupelRückgabe.Alter);

            var (firstname, lastname, age) = p; //Deconstruct wird in C# 9.0 weiter verwendet -> Gehört zum Reportaire einer Klassen (kann-regel) 
            var (firstname1, lastname1) = p;
            #endregion


            #region ref by return
            int[] zahlen = { 5, 6, 7, 8, 9, 10 };

            ref int returnValue = ref Zahlensuche(9, zahlen);
            returnValue = 123;
            Console.WriteLine("Ausgabe des Zahlen-Arrays");
            foreach (int i in zahlen)
                Console.WriteLine(i);
            #endregion

            MethodeMitDefaultParameter(123);
            MethodeMitDefaultParameter(123, 456);
            MethodeMitDefaultParameter(123, 456, 789);
        }

        private static bool MyTryParse(string eingabe, out int toCheck)
        {
            for (int i = 0; i < eingabe.Length; i++)
            {
                if (!char.IsDigit(eingabe[i]))
                {
                    throw new ArgumentException();
                }
            }

            toCheck = Convert.ToInt32(eingabe);
            return true;
        }

        public static ref int Zahlensuche(int gesuchteZahl, int[] zahlen)
        {
            for (int i = 0; i < zahlen.Length; i++)
            {
                if (zahlen[i] == gesuchteZahl)
                    return ref zahlen[i];
            }

            throw new IndexOutOfRangeException();
        }



        public static void MethodeMitDefaultParameter(int zahl1, int zahl2 = default, int zahl3 = default)
        {
            Console.WriteLine($"{zahl1 + zahl2 + zahl3}");
        }
    }




    public class Person
    {
        public string Name { get; set; }

        public string Vorname { get; set; }

        public int Alter { get; set; }

        //ctor + tab + tab 
        public Person()
        {

        }

        public Person(int Alter) => this.Alter = Alter;

        public Person(string Vorname, string Name, int Alter)
        {
            this.Name = Name;
            this.Alter = Alter;
            this.Vorname = Vorname;
        }


        public (string Vorname, string Name, int Alter) TupelAusgabePeron()
        {
            if (Vorname == "abc")
            {
                //Mehrzeilig 
            }

            if (Name == "abc")
                Console.WriteLine(Name);


            return (Vorname, Name, Alter);
        }

        public void Deconstruct(out string Vorname, out string Nachname, out int Alter)
        {
            Vorname = this.Vorname;
            Nachname = this.Name;
            Alter = this.Alter;
        }

        public void Deconstruct(out string Vorname, out string Nachname)
        {
            Vorname = this.Vorname;
            Nachname = this.Name;
            Alter = this.Alter;
        }


        public void TestMethode(out int Alter, out string Nachname)
        {
            Alter = this.Alter;
            Nachname = this.Name;
        }
    }




}
