using System;
using System.Threading.Tasks;

namespace _009_AsynAwaitPattern
{
    internal class Program
    {
        static async void Main(string[] args)
        {
            //Mit Task
            Task<string> task = Task.Run(DayTime);
            Task myTask = task.ContinueWith(t => ShowDayTime(task.Result), TaskContinuationOptions.OnlyOnRanToCompletion);
            myTask.Wait(); //Callback-Mechanismus 

            
            //Mit asyn/await -> await hat einen callback Mechanismus 
            string theCoolerReturnValue = await Task.Run(DayTime);
           
            await Task.Run(() => ShowDayTime(theCoolerReturnValue)));


        }


        public static string DayTime()
        {
            DateTime date = DateTime.Now;

            return date.Hour > 17
                ? "evening"
                : date.Hour > 12
                ? "afternoon"
                : "morning";
        }

        public static void ShowDayTime(string result)
        {
            Console.WriteLine(result);
        }
    }
}
