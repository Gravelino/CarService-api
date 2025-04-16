using Application.Interfaces;

namespace Application.Models;

public class ServiceTool : ISoftDeletable
{
    public int ServicesId { get; set; }
    public int ToolsId { get; set; }
    public Service Service { get; set; }
    public Tool Tool { get; set; }
    public DateTime? DeletedAt { get; set; }
}