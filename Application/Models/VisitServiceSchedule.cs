namespace Application.Models;

public class VisitServiceSchedule
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    
    public int VisitServiceId { get; set; }
    public VisitService? VisitService { get; set; }
    
    public int WorkerId { get; set; }
    public Worker? Worker { get; set; }
}