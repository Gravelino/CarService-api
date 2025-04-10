namespace Application.Models;

public class JobSchedule: ISoftDeletable
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    
    public int JobId { get; set; }
    public Job? Job { get; set; }
    
    public int WorkerId { get; set; }
    public Worker? Worker { get; set; }
    public DateTime? DeletedAt { get; set; }
}