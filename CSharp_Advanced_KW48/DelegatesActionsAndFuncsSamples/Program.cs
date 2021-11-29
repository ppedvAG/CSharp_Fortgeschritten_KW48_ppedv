// See https://aka.ms/new-console-template for more information

ClassWithMethods classWithMethods = new ClassWithMethods();
#region DelegateSample





ChangeNumber changeNumberDelegate = new ChangeNumber(classWithMethods.AddNumber); // ChangeNumber(classWithMethods.AddNumber) = Funktionszeiger ->  zeigt auf eine Adresse im Speicher, in dem die Methode AddNumber hinterlegt ist
int result = changeNumberDelegate(123);
Console.WriteLine(result);

ChangeNumber changeNumberDelegate2 = new ChangeNumber(classWithMethods.SubNumber);
result = changeNumberDelegate2(123);
Console.WriteLine(result);



ChangeNumber multiFunctions = new ChangeNumber(classWithMethods.AddNumber);
multiFunctions += classWithMethods.SubNumber;

result = multiFunctions(123);
//Was ist ein Delegate -> ein Datentyp 
Console.WriteLine(result);


multiFunctions -= classWithMethods.SubNumber;
result = multiFunctions(123);



//Was ist ein Delegate -> ein Datentyp 
Console.WriteLine(result);
#endregion




DelegateWithNoReturnAndParameters delegateWithNoReturnAndParameters = new DelegateWithNoReturnAndParameters(classWithMethods.MethodeA);

Action meineActionDelegate = new Action(classWithMethods.MethodeA);
meineActionDelegate();

Action<int, int> actionWithToIntegerParameter = new Action<int, int>(classWithMethods.MethodeB);
actionWithToIntegerParameter(11, 22);

actionWithToIntegerParameter += classWithMethods.MethodeC;

actionWithToIntegerParameter(11, 22); //Methode A und Methode B werden aufgerufen


Func<int, int> meineAddNumberFunc = new Func<int, int>(classWithMethods.AddNumber);
int result1 = meineAddNumberFunc(11);

#region Delegate Samples
delegate void DelegateWithNoReturnAndParameters();
delegate int ChangeNumber(int number);
//Dieses Delegate kann nur mit Methoden zusammenarbeiten, mit der selben Singatur (Rückgabetyp + Parametertypen)
#endregion

public class ClassWithMethods
{
    public int AddNumber(int number)
    {
        return number + 5;
    }

    public int SubNumber(int zahl)
    {
        return zahl - 3;
    }

    public void MethodeA()
    {
        Console.WriteLine("CallMethodeA");
    }

    public void MethodeB(int Zahl1, int Zahl2)
    {
        Console.WriteLine(Zahl1 + Zahl2);
    }

    public void MethodeC(int Zahl1, int Zahl2)
    {
        Console.WriteLine(Zahl1 - Zahl2);
    }
}







