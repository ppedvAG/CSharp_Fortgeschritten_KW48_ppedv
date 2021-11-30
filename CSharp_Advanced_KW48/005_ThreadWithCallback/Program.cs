using System;
using System.Threading;

namespace _005_ThreadWithCallback
{
    public delegate void ExampleCallback(MyReturnObject myReturnObject);
    internal class Program
    {
        static void Main(string[] args)
        {
            ThreadWithState tws = new ThreadWithState("Hallo Liebe Teilnehmer", 111, new ExampleCallback(ResultCallback));

            Thread t = new Thread(new ThreadStart(tws.ThreadProc));
            t.Start();
            Console.WriteLine("Main Thread macht irgendwas anderes");

            t.Join();
            Console.WriteLine("Unabhängiger Thread ist jetzt mit seiner Arbeit fertig geworden");

            Console.ReadLine();
        }

        public static void ResultCallback(MyReturnObject myReturnObject)
        {
            Console.WriteLine($"Rückgabewerte -> {myReturnObject.Zahl} {myReturnObject.Text}");
        }
    }

    

    public class ThreadWithState
    {
        private string myStringText;
        private int myNumberValue;
        private ExampleCallback callback;

        public ThreadWithState(string text, int number, ExampleCallback callbackDelegate)
        {
            this.myStringText = text;
            this.myNumberValue = number;
            this.callback = callbackDelegate;
        }


        public void ThreadProc()
        {
            Console.WriteLine(myStringText);
            Console.WriteLine(myNumberValue);

            //Mach etwas in diesem Thread



            //Aufbau des ReturnValues
            MyReturnObject myReturnObject = new MyReturnObject();
            myReturnObject.Text = myStringText;
            myReturnObject.Zahl = myNumberValue;

            if(callback != null)
                callback(myReturnObject); //-> ResultCallback wird via delegate aufgerufen
        }

    }



    //Diese Klasse wird nur als Parameter verwenden
    public class MyReturnObject
    {
        //ctor + tab + tab -> Konstruktor
        public MyReturnObject()
        {
        }
        public string Text { get; set; }
        public int Zahl { get; set; }
    }
}
