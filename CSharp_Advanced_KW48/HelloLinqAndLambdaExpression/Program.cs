using System;
using System.Collections.Generic;
using System.Linq;

namespace HelloLinqAndLambdaExpression
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IList<Person> persons = new List<Person>()
            {
                new Person {Id=1, Age=37, Vorname="Kevin", Nachname="Winter"},
                new Person {Id=2, Age=29, Vorname="Hannes", Nachname="Preishuber"},
                new Person {Id=3, Age=19, Vorname="Scott", Nachname="Hunter"},

                new Person {Id=4, Age=21, Vorname="Scott", Nachname="Hanselmann"},
                new Person {Id=5, Age=45, Vorname="Daniel", Nachname="Roth"},
                new Person {Id=6, Age=50, Vorname="Bill", Nachname="Gates"},

                new Person {Id=7, Age=70, Vorname="Newton", Nachname="King"},
                new Person {Id=8, Age=40, Vorname="Andre", Nachname="R"},
                new Person {Id=9, Age=60, Vorname="Petra", Nachname="Musterfrau"},
            };

            #region LinqStatement  und Linq-Functions
            //Linq Statement 
            IList<Person> personBetween40And50 = (from p in persons
                                                  where p.Age >= 40 && p.Age <= 50
                                                  orderby p.Nachname
                                                  select p).ToList();


            //Linq-Functions + Lambda Statements
            IList<Person> personBetween40And50B = persons.Where(p => p.Age >= 40 && p.Age <= 50)
                                                         .OrderBy(o => o.Vorname) //Erstes Kriterium
                                                         .ThenBy(a=>a.Age) //Zweites Kriterium 
                                                         .ToList();
            #endregion

            #region Calculationen
            //Altersduchschnitt ermitteln 
            double altersdurchschnit = persons.Average(a => a.Age);

            double alterdurchschnittAllerMitarbeitÜber40 = persons.Where(p => p.Age > 40) //selektiere alle Mitarbeiter über 40
                                                                  .Average(a => a.Age); //Ermittele von allen Mitarbeiter über 40 das Durchschnittsalter

            //Gesamtalter aller Mitarbeiter
            double gesamtAlterAlleMitarbeiter = persons.Sum(a => a.Age);
            #endregion

            #region Ermittlung einzelner Datensätze

            //Bei Single muss ein valides Ergebnis geliefert werden 
            Person einePerson = persons.Single(p => p.Id == 4);

            Person defaultPerson = persons.SingleOrDefault(p=>p.Id == 15);
                            
            if (defaultPerson != null)
            {
                Console.WriteLine(defaultPerson.Vorname); 
            }



            Person erstePersonInListe = persons.First(p => p.Age > 40);
            //FirstOrDefault gibt es auf :-) 
            Person letztePersonInListe = persons.Last(p => p.Age > 40);
            //LastOrDefault und FirstOrDefault, stellt sicher, dass wir mitbekommen, wenn KEIN Ergebnis zurückgegeben wurde 
            #endregion

            #region Verfügbarkeiten

            //Gibt es Datensätze in der Liste?
            if (persons.Count > 0)
            {
                //Datensätze sind vorhanden
            }

            //Linq-Variante von Count 
            int counter = persons.Count(p => p.Vorname.Contains("Scott"));


            //Gibt es irgendein Element (true or false wird zurück gegeben)
            if (persons.Any())
            {

            }

            if (persons.Any(p=>p.Vorname == "Hannes"))
            {
                //Es gibt Mitarbeiter mit dem Namen Hannes 
            }

            #endregion



            #region Pagging 
            int pagingNumber = 1; //Auf welcher Seite befinde ich mich -> [1] 2 3 
            int pagingSize = 3; //Anzahl der Elemente, die auf einer Seite angezeigt werden 

            IList<Person> ergebnisSeite1 = persons.Skip((pagingNumber - 1) * pagingSize).Take(pagingSize).ToList();

            pagingNumber = 2;
            IList<Person> ergebnisSeite2 = persons.Skip((pagingNumber - 1) * pagingSize).Take(pagingSize).ToList();


            pagingNumber = 3;
            IList<Person> ergebnisSeite3 = persons.Skip((pagingNumber - 1) * pagingSize).Take(pagingSize).ToList();
            #endregion

        }
    }



    public class Person
    {
        public int Id { get; set; }
        public int Age { get; set; }

        public string Vorname { get; set; }
        public string Nachname { get; set; }
    }
}
