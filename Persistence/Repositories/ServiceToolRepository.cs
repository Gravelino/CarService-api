using Application.Interfaces;
using Application.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Persistence.Repositories;

public class ServiceToolRepository : SoftDeletableRepository<ServiceTool>, IServiceToolRepository
{
    public ServiceToolRepository(CarServiceDbContext context) : base(context)
    {
        
    }

    public async Task DeleteByServiceIdAsync(int serviceId)
    {
        var servicesTools = await _context.ServiceTools
            .Where(st => st.ServicesId == serviceId)
            .ToListAsync();

        _context.ServiceTools.RemoveRange(servicesTools);
    }

    public async Task DeleteByServiceAndToolIdAsync(int serviceId, int toolId)
    {
        var serviceTool = await _context.ServiceTools
            .FirstOrDefaultAsync(st => st.ServicesId == serviceId && st.ToolsId == toolId);

        if (serviceTool != null)
        {
            _context.ServiceTools.Remove(serviceTool);
        }
    }

    public async Task<IEnumerable<int>> GetToolIdsByServiceIdAsync(int serviceId)
    {
        return await _context.ServiceTools
            .Where(st => st.ServicesId == serviceId)
            .Select(st => st.ToolsId)
            .ToListAsync();
    }
}