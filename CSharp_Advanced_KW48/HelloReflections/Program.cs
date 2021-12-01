using System;
using System.Reflection; 

namespace HelloReflections
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly geleadeneDll = Assembly.LoadFrom("Taschenrechner.dll");

            Type taschenrechnerClass = geleadeneDll.GetType("Taschenrechner.Rechner");


           
            object tr = Activator.CreateInstance(taschenrechnerClass);

            MethodInfo addMethodInfo = taschenrechnerClass.GetMethod("Add", new Type[] { typeof(Int32), typeof(Int32) });

            var result = addMethodInfo.Invoke(tr, new object[] { 11, 22 });

            Console.WriteLine(result); 
        }
    }
}
