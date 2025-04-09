using Application.Interfaces;
using Application.Models;
using Persistence.Data;

namespace Persistence.Repositories;

public class ServiceCategoryRepository : SoftDeletableRepository<ServiceCategory>, IServiceCategoryRepository
{
    public ServiceCategoryRepository(CarServiceDbContext context) : base(context)
    {
    }
}