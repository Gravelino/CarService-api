using Application.Models;

namespace Persistence.Repositories;

public interface IFeedbackRepository :IRepository<Feedback>
{
    Task<IEnumerable<Feedback>> GetFeedbackForVisitAsync(int visitId);
    Task<decimal> GetAverageRatingForServiceAsync(int serviceId);
}