namespace Application.Models;

public class Mechanic
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Specialization { get; set; }
    public DateTime HireDate { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public decimal Salary { get; set; }
    public bool IsBooked { get; set; }
}