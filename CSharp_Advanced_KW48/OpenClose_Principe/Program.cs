// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

IReportGenerateBase report = new PDFGenerator();
report.Generate();

#region BadCode
public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}


public class BadReportGenerator
{
    /// <summary>
    /// Report type
    /// </summary>
    public string ReportType { get; set; } = string.Empty;

    /// <summary>
    /// Method to generate report
    /// </summary>
    /// <param name="em"></param>
    public void GenerateReport(Employee em)
    {
        if (ReportType == "CR")
        {
            // Report generation with employee data in Crystal Report.
        }
        if (ReportType == "PDF")
        {
            //Libary für PDF Export
            //Fülllogik us
            // Report generation with employee data in PDF.
        }
    }

    //private void CR_LoadTemplate(string Path);


    //private void PDF_Compress();
}
#endregion

#region Open Close with abstract class
public interface IReportGenerateBase
{
    void Generate();
}
public abstract class ReportGenerateBase : IReportGenerateBase//Open : 
{
    public abstract void Generate();

    private void DoAnything()
    { 
        //Für Gemeinsamkeiten
    }
}

public class PDFGenerator : ReportGenerateBase
{

    public override void Generate()
    {
        //cw + Tab -> Console.WriteLine
        Console.WriteLine("generiere ein PDF");
    }
}

public class CrystalReportsGenerator : ReportGenerateBase
{
    public override void Generate()
    {
        //cw + Tab -> Console.WriteLine
        Console.WriteLine("generiere ein Crystal Report");
    }
}

#endregion


#region Gute Lösung 2

public interface IGenerator
{
    void Generator();

    private void DoAnything()
    {

    }
}

public class PDFGenerator1 : IGenerator
{
    public void Generator()
    {
        throw new NotImplementedException();
    }
}
#endregion


//Warum eine abstrakte Klasse -> 
