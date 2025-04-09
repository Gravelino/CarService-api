namespace Application.Models;

public class Worker : ISoftDeletable
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Specialization { get; set; }
    public DateTime HireDate { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public decimal Salary { get; set; }
    public bool IsActive { get; set; }
    public DateTime? DeletedAt { get; set; }
    
    public ICollection<JobSchedule>? JobSchedules { get; set; }
    public ICollection<WorkerService>? WorkerServices { get; set; }
}