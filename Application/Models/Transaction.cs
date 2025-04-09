namespace Application.Models;

public class Transaction
{
    public int Id { get; set; }
    public string Status { get; set; }
    public DateTime TransactionDate { get; set; }
    
    public int PaymentId { get; set; }
    public Payment? Payment { get; set; }
}