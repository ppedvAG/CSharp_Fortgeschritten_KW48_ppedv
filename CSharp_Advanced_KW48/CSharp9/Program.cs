using System;

namespace CSharp9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PersonRecord personRecord1 = new PersonRecord(1, "Mario Bart");
            PersonRecord personRecord2 = new PersonRecord(1, "Mario Bart");

            PersonClass myPerson1Class = new PersonClass(1, "Helge Schneider");
            PersonClass myPerson2Class = new PersonClass(1, "Helge Schneider");


            #region Class vs Record  -> = - Operator
            if (myPerson1Class == myPerson2Class)
            {
                Console.WriteLine("myPerson1Class == myPerson2Class -> gleich");
            }
            else
            {
                Console.WriteLine("myPerson1Class == myPerson2Class -> ungleich");
            }


            if (personRecord1 == personRecord2)
            {
                Console.WriteLine("personRecord1 == personRecord2 -> gleich");
            }
            else
            {
                Console.WriteLine("personRecord1 == personRecord2 -> ungleich");
            }
            #endregion

            if (myPerson1Class.Equals(myPerson2Class))
            {
                Console.WriteLine("myPerson1Class.Equals(myPerson2Class) -> gleich");
            }
            else
            {
                Console.WriteLine("myPerson1Class.Equals(myPerson2Class) -> ungleich");
            }

            if (personRecord1.Equals(personRecord1))
            {
                Console.WriteLine("personRecord1.Equals(personRecord2) -> gleich");
            }
            else
            {
                Console.WriteLine("personRecord1.Equals(personRecord2) -> ungleich");
            }

            //personRecord1.Name = "HArry"; -> geht nicht per Default -> public record PersonRecord(int Id, string Name); 
            //Die kurze Record schreibweise sind die Properties init und nicht set 

            (int id, string name) = personRecord1; //Dekonstruktion per Default mit dabei 



            //Person Record Sample with With

            Person person1 = new("Nancy", "Davolio") { PhoneNumbers = new string[2] { "1234", "5678" } };

            Console.WriteLine("Ausgabe von Record -> ToString()");
            Console.WriteLine(person1); // ->  person1.ToString();
            // output: Person { FirstName = Nancy, LastName = Davolio, PhoneNumbers = System.String[] }


            Person person2 = person1 with { FirstName = "John" }; //Kopieren von person1 auf person2 und manipulieren dabei eine Property (init) 
            //person2.FirstName = "Geht nicht"; 
        }
    }


    public record PersonRecord(int Id, string Name);
    public class PersonClass
    {
        public PersonClass(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }



    public record EmployeeRecord : PersonRecord
    {
        public decimal Gehalt { get; set; } //Record könnenn auch Set Variablen 


        public EmployeeRecord(int Id, string Name)
             : base(Id, Name)
        {

        }

        public EmployeeRecord(int Id, string Name, decimal Gehalt)
           : base(Id, Name)
        {
            this.Gehalt = Gehalt;
        }

    }

   




    public record Person(string FirstName, string LastName)
    {
        public string[] PhoneNumbers { get; init; }

        public string Haribo { get; set; }
    }
}
