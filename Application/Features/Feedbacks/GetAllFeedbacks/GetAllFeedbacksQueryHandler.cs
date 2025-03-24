using System.Xml;
using Application.Models;
using MediatR;
using Persistence.Repositories.Interfaces;

namespace Application.Features.Feedbacks.GetAllFeedbacks;

public class GetAllFeedbacksQueryHandler : IRequestHandler<GetAllFeedbacksQuery, IEnumerable<Feedback>>
{
    private readonly IFeedbackRepository _feedbackRepository;

    public GetAllFeedbacksQueryHandler(IFeedbackRepository feedbackRepository)
    {
        _feedbackRepository = feedbackRepository;
    }

    public async Task<IEnumerable<Feedback>> Handle(GetAllFeedbacksQuery request, CancellationToken cancellationToken)
    {
        var feedbacks = await _feedbackRepository.GetAllAsync();
        return feedbacks.Where(f => f.DeletedAt == null).ToList();
    }
}