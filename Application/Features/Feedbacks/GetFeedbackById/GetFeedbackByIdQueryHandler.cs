using Application.Models;
using MediatR;
using Persistence.Repositories.Interfaces;

namespace Application.Features.Feedbacks.GetFeedbackById;

public class GetFeedbackByIdQueryHandler : IRequestHandler<GetFeedbackByIdQuery, Feedback?>
{
    private readonly IFeedbackRepository _feedbackRepository;

    public GetFeedbackByIdQueryHandler(IFeedbackRepository feedbackRepository)
    {
        _feedbackRepository = feedbackRepository;
    }

    public async Task<Feedback?> Handle(GetFeedbackByIdQuery request, CancellationToken cancellationToken)
    {
        var feedback = await _feedbackRepository.GetByIdAsync(request.FeedbackId);
        return feedback;
    }
}