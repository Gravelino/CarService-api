namespace Application.DTOs;

public class AvailableSlotDto
{
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public int WorkerId { get; set; }
    public string WorkerName { get; set; }
}