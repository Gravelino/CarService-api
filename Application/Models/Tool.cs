namespace Application.Models;

public class Tool : ISoftDeletable
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int SerialNumber { get; set; }
    public DateTime? DeletedAt { get; set; }
    public ICollection<Service> Services { get; set; }
    public ICollection<ServiceTool> ServiceTools { get; set; }

}