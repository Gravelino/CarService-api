using Application.Models;

namespace Application.Interfaces;

public interface IPaymentRepository : ISoftDeletableRepository<Payment>
{
    Task<IEnumerable<Payment>> GetPaymentsByVisitIdAsync(int visitId);
    Task<decimal> GetTotalPaymentsForVisitAsync(int visitId);
}