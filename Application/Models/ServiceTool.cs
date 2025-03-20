namespace Application.Models;

public class ServiceTool
{
    public int Id { get; set; }
    public int ServiceId { get; set; }
    public Service? Service { get; set; }
    
    public int ToolId { get; set; }
    public Tool? Tool { get; set; }
}