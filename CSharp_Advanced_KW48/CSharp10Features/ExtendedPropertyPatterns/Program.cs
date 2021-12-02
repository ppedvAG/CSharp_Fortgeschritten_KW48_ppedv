// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

PersonModel person = new();

if (person is { FirstName: "Kevin" })
{
    Console.WriteLine("Hello Kevin");
}

if (person is { HomeAddress.City: "Berlin"})
{
    Console.WriteLine("You are in Berlin");
}

if (person is { FirstName: "Kevin", LastName:"Winter", HomeAddress.Country:"Kanada" ,HomeAddress.City: "Berlin" })
{
    
}


class PersonModel
{
    public string FirstName { get; set; } = "Kevin";
    public string LastName { get; set; } = "Winter";

    public AddressModel HomeAddress { get; set; } = new AddressModel();
}

class AddressModel
{
    public string City { get; set; } = "Berlin";
    public string Country { get; set; } = "Germany";
}