using System.Net.NetworkInformation;

namespace Application.Models;

public interface ISoftDeletable
{
    public DateTime? DeletedAt { get; set; } 
}