using Application.Models;

namespace Application.Interfaces;

public interface ISoftDeletableRepository<TEntity> : IRepository<TEntity> where TEntity : class, ISoftDeletable
{
    Task SoftDeleteAsync(int id);
    Task RestoreAsync(int id);
}