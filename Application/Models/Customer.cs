namespace Application.Models;

public class Customer : ISoftDeletable
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public DateTime RegistrationDate { get; set; }
    public DateTime? DeletedAt { get; set; }
    
    public ICollection<Car>? Cars { get; set; }
    public ICollection<Visit>? Visits { get; set; }
}