﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _008_Task_WhenAllSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Task<int>> taskCollection = new List<Task<int>>();

            for (int counter = 1; counter <= 10; counter++)
            {
                int baseValue = counter;

                taskCollection.Add(Task.Factory.StartNew(b => (int)b * (int)b, baseValue));
            }


            //Alle Ergebnisse meiner Task von taskCollection
            Task<int[]> taskResults = Task.WhenAll(taskCollection);
            
            //1,2,4,9,16,25....
            int[] results = taskResults.Result;


            int sum = 0;


            for (int counter = 0; counter <= results.Length -1; counter++)
            {
                var result = results[counter];

                Console.Write($"{result} {((counter ==results.Length-1) ? "=" : "+")}");
                sum += result;
            }
            Console.WriteLine(sum);

        }
    }
}
