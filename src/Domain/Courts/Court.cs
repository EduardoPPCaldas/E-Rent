namespace Domain.Courts;

public class Court
{
    public Court(string name, string description, decimal price, string streetName, string addressNumber, string zipCode, string country)
    {
        Name = name;
        Description = description;
        Price = price;
        StreetName = streetName;
        AddressNumber = addressNumber;
        ZipCode = zipCode;
        Country = country;
    }

    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string StreetName { get; set; }
    public string AddressNumber { get; set; }
    public string ZipCode { get; set; }
    public string Country { get; set; }
}
