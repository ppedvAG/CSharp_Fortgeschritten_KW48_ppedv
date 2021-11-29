using System;

namespace EventAndEventHandlerInNET5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProcessBusinessLogic processBusinessLogic = new ProcessBusinessLogic();
            processBusinessLogic.ProcessCompleted += ProcessBusinessLogic_ProcessCompleted;
            processBusinessLogic.CurrentPercentStatus += ProcessBusinessLogic_CurrentPercentStatus;

            processBusinessLogic.StartProcess();


            ProcessBusinessLogic2 processBusinessLogic2 = new ProcessBusinessLogic2();
            processBusinessLogic2.ProcessCompleted += ProcessBusinessLogic2_ProcessCompleted;
            processBusinessLogic2.StartProcess();
            
            
            
            processBusinessLogic2.ProcessCompletedWithArgument += ProcessBusinessLogic2_ProcessCompletedWithArgument;
            processBusinessLogic2.StartProcess2();



            


        }

        private static void ProcessBusinessLogic2_ProcessCompletedWithArgument(object sender, EventArgs e)
        {
            MyEventArg myEventArg = (MyEventArg)e;
            Console.WriteLine(myEventArg.Uhrzeit.ToString());
        }

        private static void ProcessBusinessLogic2_ProcessCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("ProcessBusinessLogic ist fertig mit der Methode StartProcess ");
        }

        private static void ProcessBusinessLogic_CurrentPercentStatus(int n)
        {
            Console.WriteLine(n);
        }

        private static void ProcessBusinessLogic_ProcessCompleted()
        {
            //Hier landen wir, wenn processBusinessLogic.StartProcess fertig ist
            Console.WriteLine("bin fertig");
        }


    }
}
