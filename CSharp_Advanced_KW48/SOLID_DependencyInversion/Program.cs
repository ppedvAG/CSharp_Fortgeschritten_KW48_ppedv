// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

BadCarService badCarService = new();
badCarService.RepairCar(new BadCar());


ICar car = new Car(); //Produktive Objekt
ICar mockCar = new Car();

ICarService carService = new CarService();
carService.RepairCar(car);
carService.RepairCar(mockCar);





//Was ist nicht schön:

//Struktur wird zu einem Monolithen -> mit vordauerner Produktzeit, werden Implementierungen teurer
#region BadCode
public class BadCar //Programmierer A: 5 Tage
{
    public int Id { get; set; }
    public string Brand { get; set; } = default!;
    public string Model { get; set; } = string.Empty;
}


public class BadCarService //Programmierer B: 3 Tage
{
    public void RepairCar(BadCar car)
    {
        //repariere Auto 
    }
}

//Ergebnis 8 Tage und danach kommt die Funktionstestphase

#endregion

//Contract First -> WCF / GRPC 
#region Contract First ->Definition der Interfaces
public interface ICar
{
    int Id { get; set; }    
    string Brand { get; set; }  
    string Model { get; set; }  
}

public interface ICarService
{
    void RepairCar(ICar car);
}

#endregion

public class Car : ICar //Programmierer A -> 5 Tage
{
    public int Id { get; set; }
    public string Brand { get; set; } = default!;
    public string Model { get; set; } = string.Empty;
}

public class MockCar : ICar
{
    public int Id { get; set; } = 1;
    public string Brand { get; set; } = "VW";
    public string Model { get; set; } = "Polo";
}





public class CarService : ICarService //Programmierer B: 3 Tage 
{
    public void RepairCar(ICar car)
    {
        //Repariere Auto
    }
}


//Was ist ein  IOC Container?

//---- Interface --- | --- Implementierte Klasse 

// ICar              | Car (fertig instanziiert) 
// ICarService       | CarService

