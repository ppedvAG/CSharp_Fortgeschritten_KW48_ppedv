using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GenericSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Liste verwenden intern ein T[] von 4 Feldern, wenn diese 4 Felder befüllt sind, verdoppelt er das interne array um das doppelte
            IList<string> nameList = new List<string>();
            nameList.Add("Harry Weinfuhrt");

            IDictionary<int, string> dict = new Dictionary<int, string>();
            dict.Add(1, "Karl May");
            dict.Add(new KeyValuePair<int, string>(2, "Steven King"));

            foreach(KeyValuePair<int, string> kvp in dict)
            {
                Console.WriteLine($"{kvp.Key} \t {kvp.Value}");
            }

            //Achtung AntiBeispiel -> HashTable ist viel schlechter als Dictionary 
            Hashtable hashtable = new Hashtable();
            hashtable.Add(1, "txt");
            hashtable.Add("txt", 1);
            hashtable.Add(new StringBuilder(),  DateTime.Now);


            DataStore<string> dataStore = new DataStore<string>();
            dataStore.AddOrUpdate(0, "Harry");
            dataStore.AddOrUpdate(1, "Hannes");
            dataStore.AddOrUpdate(1, "Klaas");
        }
    }




    public class DataStore<T>
    {
        private T[] _data = new T[10];

        
        public T[] Data
        {
            get => _data;
            set => _data = value;
        }

        public void AddOrUpdate(int index, T item)
        {
            if (index >= 0 && index < 10)
                _data[index] = item;
        }

        public T GetData(int index)
        {
            if (index >= 0 && index < 10)
                return _data[index];
            else
                return default(T);
        }


        public void DisplayDefault<MyType>()
        {
            MyType item = default(MyType);
            Console.WriteLine($"Default value of {typeof(MyType)} is {(item == null ? "null" : item.ToString())}.");
        }
    }
}
