namespace Application.Interfaces;

public interface IRepository<TEntity> where TEntity : class
{
    IQueryable<TEntity> GetAllAsync();
    Task<TEntity?> GetByIdAsync(int id);
    Task AddAsync(TEntity entity);
    Task Update(TEntity entity);
    Task Delete(TEntity entity);
    Task SaveChangesAsync();
}