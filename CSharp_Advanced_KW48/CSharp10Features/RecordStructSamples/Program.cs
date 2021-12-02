// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

#region Records in c# 9
public record Person(string FirstName, string LastName);

public record Person2
{
    public string FirstName { get; init; } = default!;
    public string LastName { get; init; } = default!;
};

//Sie können auch Datensatztypen mit änderbaren Eigenschaften und Feldern erstellen:
public record Perso3
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
};
#endregion


#region Records Structs in C# 10
//Sie können auch Strukturtypen verwenden, um datenzentrierte Typen zu entwerfen,
//die Wertgleichheit und wenig oder kein Verhalten bereitstellen.
//In C# 10 und höher können Sie record struct-Typen mithilfe von Positionsparametern oder einer Standardeigenschaftssyntax definieren:



//Kompakt
public readonly record struct Point(double X, double Y, double Z);
//Ausgeschrieben
public record struct Point1
{
    public double X { get; init; }
    public double Y { get; init; }
    public double Z { get; init; }
}


//Kompakt
public record struct DataMeasurement(DateTime TakenAt, double Measurement);

//Ausgeschrieben
public record struct Point
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }
}
#endregion
