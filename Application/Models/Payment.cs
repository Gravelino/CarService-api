namespace Application.Models;

public class Payment
{
    public int Id { get; set; }
   
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public string PaymentMethod { get; set; } 
    public string Status { get; set; } 
    public string Currency { get; set; } 
    
    public int VisitId { get; set; }
    public Visit? Visit { get; set; }
}