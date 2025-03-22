using Application.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Persistence.Repositories.Interfaces;

namespace Persistence.Repositories;

public class PaymentRepository : SoftDeletableRepository<Payment>, IPaymentRepository
{
    public PaymentRepository(CarServiceDbContext dbContext) : base(dbContext)
    {
        
    }

    public async Task<IEnumerable<Payment>> GetPaymentsByVisitIdAsync(int visitId)
    {
        return await _context.Payments
            .Where(p => p.VisitId == visitId)
            .ToListAsync();
    }

    public async Task<decimal> GetTotalPaymentsForVisitAsync(int visitId)
    {
        return await _context.Payments
            .Where(p => p.VisitId == visitId)
            .SumAsync(p => p.Amount);
    }
}