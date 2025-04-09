using Application.Models;

namespace Application.Interfaces;

public interface IFeedbackRepository :ISoftDeletableRepository<Feedback>
{
    Task<IEnumerable<Feedback>> GetFeedbackForVisitAsync(int visitId);
    Task<double> GetAverageRatingForServiceAsync(int serviceId);
}