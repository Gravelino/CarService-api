namespace Application.Interfaces;

public interface IRepository<TEntity> where TEntity : class
{
    public Task<IEnumerable<TEntity>> GetAllAsync();
    public Task<TEntity?> GetByIdAsync(int id);
    Task AddAsync(TEntity entity);
    Task Update(TEntity entity);
    Task Delete(TEntity entity);
    Task SaveChangesAsync();
}