namespace Application.Models;

public class WorkerService
{
    public int Id { get; set; }
    public int Price { get; set; }
    
    public int WorkerId { get; set; }
    public Worker? Worker { get; set; }
    
    public int ServiceId { get; set; }
    public Service? Service { get; set; }
}