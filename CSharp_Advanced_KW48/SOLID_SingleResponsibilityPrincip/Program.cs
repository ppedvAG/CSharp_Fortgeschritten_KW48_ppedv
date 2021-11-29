// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");



// .NET 5.0 

//using System;

//namespace SOLID_SingleResponsibilityPrincip
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Hello World!");
//            Console.ReadLine();
//        }
//    }
//}

#region Schlechtes Beispiel

public class EmployeeBad
{

    #region Datenstruktur
    public int Id { get; set; } 
    public string Name { get; set; } = string.Empty;
    #endregion


    #region InsertIntoEmployeeTable - > Muss DataAccess - Layer
    public bool InsertIntoEmployeeTable(EmployeeBad em)
    {
        // Insert into employee table.
        return true;
    }
    #endregion

    #region Reports liegen als Library meist vor -> Generate Report (Präsentation - Layer) 
    /// <summary>
    /// Method to generate report
    /// </summary>
    /// <param name="em"></param>
    public void GenerateReport(EmployeeBad em)
    {
        // Report generation with employee data using crystal report.
    }
    #endregion
}
#endregion

public class Empolyee
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    //...
}

public class ReportGenerator
{
    public void Generator()
    {
        // Wir erstellen eine PDF / CrystalReports / List10
    }

    //Optionale Funktionalitäten
}

public class ReportRepository //Ich rede mit der Datenbank 
{
    public void Insert(Empolyee employee)
    {
        //Employee wird in die Tabelle (DB) eingefügt. 
    }
}





