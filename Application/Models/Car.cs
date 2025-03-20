namespace Application.Models;

public class Car
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public string LicensePlate { get; set; }
    public string Color { get; set; }
    public DateTime LastServiceDate { get; set; }
    
    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }
}