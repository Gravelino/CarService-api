using MediatR;

namespace Application.Features.Feedbacks.GetAverageServiceRating;

public class GetAverageServiceRatingQuery : IRequest<double>
{
    public int ServiceId { get; set; }
}