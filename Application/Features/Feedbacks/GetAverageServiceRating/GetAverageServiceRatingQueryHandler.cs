using Application.Interfaces;
using MediatR;

namespace Application.Features.Feedbacks.GetAverageServiceRating;

public class GetAverageServiceRatingQueryHandler : IRequestHandler<GetAverageServiceRatingQuery, double>
{
    private readonly IFeedbackRepository _feedbackRepository;

    public GetAverageServiceRatingQueryHandler(IFeedbackRepository feedbackRepository)
    {
        _feedbackRepository = feedbackRepository;
    }

    public async Task<double> Handle(GetAverageServiceRatingQuery request, CancellationToken cancellationToken)
    {
        var result = await _feedbackRepository.GetAverageRatingForServiceAsync(request.ServiceId);
        return result;
    }
}