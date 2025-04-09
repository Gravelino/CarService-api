namespace Application.Models;

public class Job : ISoftDeletable
{
    public int Id { get; set; }
    //public int Quantity { get; set; } //????
    public decimal Price { get; set; }
    
    public int VisitId { get; set; }
    public Visit? Visit { get; set; }
    
     public int ServiceId { get; set; }
    public Service? Service { get; set; }
    public DateTime? DeletedAt { get; set; }
}