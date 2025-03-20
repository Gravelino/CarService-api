namespace Application.Models;

public class MechanicService
{
    public int Id { get; set; }
    public int Price { get; set; }
    
    public int MechanicId { get; set; }
    public Mechanic? Mechanic { get; set; }
    
    public int ServiceId { get; set; }
    public Service? Service { get; set; }
}