namespace Persistence.Repositories;

public interface IRepository<TEntity> where TEntity : class
{
    public Task<IEnumerable<TEntity>> GetAllAsync();
    public Task<TEntity?> GetByIdAsync(int id);
    Task AddAsync(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    Task SaveChangesAsync();
}