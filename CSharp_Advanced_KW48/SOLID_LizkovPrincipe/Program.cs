// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

#region BadCode
public class BadKirsche
{
    public string GetColour()
    {
        return "Rot";
    }
}


public class BadErdbeer : BadKirsche
{
    public string GetFarbe()
    {
        return base.GetColour();
    }
}
#endregion

#region GoodCode

public abstract class Fruits
{
    public abstract string GetColour();
}


public class Erdbeer : Fruits
{
    public override string GetColour()
    {
        return "Rot";
    }
}


public class Kirsche : Fruits
{
    public override string GetColour()
    {
        return "Rot";
    }
}
#endregion