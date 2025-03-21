using Microsoft.EntityFrameworkCore;
using Persistence.Data;

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
    
    public virtual  async Task<IEnumerable<TEntity>> GetAllAsync() => await _dbSet.ToListAsync();

    public virtual  async Task<TEntity?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);
    
    public async Task AddAsync(TEntity entity) => await _dbSet.AddAsync(entity);

    public void Update(TEntity entity) => _dbSet.Update(entity);

    public void Delete(TEntity entity) => _dbSet.Remove(entity);

    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
}