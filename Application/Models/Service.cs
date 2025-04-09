namespace Application.Models;

public class Service: ISoftDeletable
{
    public int Id { get; set; }
    public string ServiceName { get; set; }
    public string Description { get; set; }
    public decimal BasePrice { get; set; }
    public int Duration { get; set; }
    public DateTime? DeletedAt { get; set; }
    
    public int ServiceCategoryId { get; set; }
    public ServiceCategory? ServiceCategory { get; set; }
    public ICollection<Tool>? Tools { get; set; }
    public ICollection<WorkerService>? WorkerServices { get; set; }
    public ICollection<Job>? Jobs { get; set; }
}