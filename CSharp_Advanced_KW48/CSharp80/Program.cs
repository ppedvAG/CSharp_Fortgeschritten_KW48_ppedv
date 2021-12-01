using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSharp80
{
    internal class Program
    {
        static void Main(string[] args)
        {


            //Ohne Default Implementierung
            ICar car = new Car(); //Dependency Injection hat man mehr Möglichkeit
            car.Beschleunigen(12);
            car.Bremsen();

            ICar2 car2 = new Car2();
            car.Beschleunigen(12); //Klassenimplementierung in Car2 wird aufgerufen
            car.Bremsen(); //Interface Implementierung wird aufgerufen 

            Car2 car3 = new Car2();
            car3.Beschleunigen(12);
            //car3.Bremsen(); findet er so nicht, weil die Klasse Car2 keine Bremsen-Methode implementiert hat


            ICar newCar = (ICar)car3;
            newCar.Beschleunigen(12);
            newCar.Bremsen();

        }


        #region AsynEnumarable with yield return

        //https://docs.microsoft.com/de-de/aspnet/core/web-api/action-return-types?view=aspnetcore-5.0
        // Wird verwendet bei Service Layer / Clients z.b grpc oder WebAPI (Return Values) 
        public static async IAsyncEnumerable<int> GeneriereZahlen()
        {
            for (int i = 0; i < 20; i++)
            {
                await Task.Delay(100);
                yield return i; //1,2,3,4,5,6,7,8,9,.....
            }
        } //Hier verlässt er die Methode

        public static async Task GebeZahlenAus()
        {
            await foreach (var zahl /*1,2,3,4,5,6,7,8*/ in GeneriereZahlen())
            {
                Console.WriteLine(zahl); //1,2,3,4,5,6,7,8
            }
        }

        #endregion
    }


    #region Interface C# 8.0 

    public interface ICar
    {
        void Bremsen();
        void Beschleunigen(int offsetKMH);
    }

    public class Car : ICar
    {
        public void Beschleunigen(int offsetKMH)
        {
            //Bitte ausimplementieren
        }

        public void Bremsen()
        {
            //Bitte ausimplementieren
        }
    }



    public interface ICar2
    {
        void Bremsen()
        {
            Console.WriteLine("Bin ICar2.DefaultMethode - Wir bremsen auf 0 kmh");
        }
        void Beschleunigen(int offsetKMH);
    }


    public class Car2 : ICar2
    {
        public void Beschleunigen(int offsetKMH)
        {

        }
    }


    #endregion
}
