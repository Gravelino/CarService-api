using Application.Models;

namespace Persistence.Repositories.Interfaces;

public interface IFeedbackRepository :IRepository<Feedback>
{
    Task<IEnumerable<Feedback>> GetFeedbackForVisitAsync(int visitId);
    Task<double> GetAverageRatingForServiceAsync(int serviceId);
}