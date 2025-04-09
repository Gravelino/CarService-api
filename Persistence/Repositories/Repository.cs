using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Application.Interfaces;

namespace Persistence.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected readonly CarServiceDbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public Repository(CarServiceDbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public virtual IQueryable<TEntity> GetAllAsync() => _dbSet.AsQueryable();

    public virtual  async Task<TEntity?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);
    
    public virtual async Task AddAsync(TEntity entity) 
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task Update(TEntity entity) 
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task Delete(TEntity entity) 
    {
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
}