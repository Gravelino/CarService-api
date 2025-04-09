namespace Application.Models;

public class Feedback : ISoftDeletable
{
    public int Id { get; set; }

    public int Rating { get; set; }
    public string Comment { get; set; } = string.Empty;
    public DateTime FeedbackDate { get; set; }  
    
    public int VisitId { get; set; }
    public Visit? Visit { get; set; }
    public DateTime? DeletedAt { get; set; }
}