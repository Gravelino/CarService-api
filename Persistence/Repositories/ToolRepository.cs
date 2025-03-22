using Application.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Persistence.Repositories.Interfaces;

namespace Persistence.Repositories;

public class ToolRepository : SoftDeletableRepository<Tool>, IToolRepository
{
    public ToolRepository(CarServiceDbContext dbContext) : base(dbContext)
    {
        
    }

    public async Task<IEnumerable<Tool>> GetToolsForServiceAsync(int serviceId)
    {
        var tools = await _context.ServiceTools
            .Where(st => st.ServiceId == serviceId)
            .Select(st => st.ToolId)
            .ToListAsync();

        return await _dbSet
            .Where(t => tools.Contains(t.Id) && t.DeletedAt == null)
            .ToListAsync();
    }

    public async Task<Tool> GetToolBySerialNumberAsync(int serialNumber)
    {
        return await _dbSet
            .FirstOrDefaultAsync(t => t.SerialNumber == serialNumber && t.DeletedAt == null);
    }
}