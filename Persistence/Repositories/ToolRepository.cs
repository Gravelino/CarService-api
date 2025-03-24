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
        var service = await _context.Services
            .Include(s => s.Tools)
            .FirstOrDefaultAsync(s => s.Id == serviceId && s.DeletedAt == null);
        if (service == null)
        {
            return [];
        }

        var tools = service.Tools.Where(t => t.DeletedAt == null).ToList();

        return tools;
    }

    public async Task<Tool?> GetToolBySerialNumberAsync(int serialNumber)
    {
        return await _dbSet
            .FirstOrDefaultAsync(t => t.SerialNumber == serialNumber && t.DeletedAt == null);
    }
}