namespace Application.Models;

public class Tool
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int SerialNumber { get; set; }
    public bool IsBooked { get; set; }
}