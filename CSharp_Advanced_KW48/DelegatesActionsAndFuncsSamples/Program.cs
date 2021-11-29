// See https://aka.ms/new-console-template for more information
ClassWithMethods classWithMethods = new ClassWithMethods();



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


Console.ReadLine();




delegate int ChangeNumber(int number);  
//Dieses Delegate kann nur mit Methoden zusammenarbeiten, mit der selben Singatur (Rückgabetyp + Parametertypen)


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
}
