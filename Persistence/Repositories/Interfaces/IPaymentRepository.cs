using Application.Models;

namespace Persistence.Repositories;

public interface IPaymentRepository : IRepository<Payment>
{
    Task<IEnumerable<Payment>> GetPaymentsByVisitIdAsync(int visitId);
    Task<decimal> GetTotalPaymentsForVisitAsync(int visitId);
}