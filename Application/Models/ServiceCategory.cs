namespace Application.Models;

public class ServiceCategory
{
    public int Id { get; set; }
    public string CategoryName { get; set; }
    public string Description { get; set; }
    public ICollection<Service> Services { get; set; }
}