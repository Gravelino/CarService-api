namespace Application.Models;


public class Visit
{
    public int Id { get; set; }
    public DateTime VisitStartDate { get; set; }
    public DateTime VisitEndDate { get; set; }
    public DateTime CompletionDate { get; set; }
    public string Status { get; set; }
    public decimal TotalPrice { get; set; }
    
    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }
    
    public int CarId { get; set; }
    public Car? Car { get; set; }
}