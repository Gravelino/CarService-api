using Application.Interfaces;
using Application.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Persistence.Repositories;

public class SoftDeletableRepository<TEntity> : Repository<TEntity>,
    ISoftDeletableRepository<TEntity> where TEntity : class, ISoftDeletable
{
    
    public SoftDeletableRepository(CarServiceDbContext context) :
        base(context) { }

    public override IQueryable<TEntity> GetAllAsync()
    {
        return _dbSet.AsQueryable().Where(e => e.DeletedAt == null);
    }

    public override async Task<TEntity?> GetByIdAsync(int id)
    {
        return await _dbSet.FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id && e.DeletedAt == null);
    } 

    public async Task SoftDeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity == null)
        {
            return;
        }

        _context.Entry(entity).Property(e => e.DeletedAt).CurrentValue = DateTime.UtcNow;
        await _context.SaveChangesAsync();
    }

    public async Task RestoreAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity == null)
        {
            return;
        }

        _context.Entry(entity).Property(e => e.DeletedAt).CurrentValue = null;
        await _context.SaveChangesAsync();
    }
}