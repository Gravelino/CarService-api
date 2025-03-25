using Application.Interfaces;
using Application.Models;
using MediatR;

namespace Application.Features.Feedbacks.GetFeedbackByVisit;

public class GetFeedbackByVisitQueryHandler : IRequestHandler<GetFeedbackByVisitQuery, IEnumerable<Feedback>>
{
    private readonly IFeedbackRepository _feedbackRepository;

    public GetFeedbackByVisitQueryHandler(IFeedbackRepository feedbackRepository)
    {
        _feedbackRepository = feedbackRepository;
    }

    public async Task<IEnumerable<Feedback>> Handle(GetFeedbackByVisitQuery request, CancellationToken cancellationToken)
    {
        var result = await _feedbackRepository.GetFeedbackForVisitAsync(request.VisitId);
        return result.Where(f => f.DeletedAt == null).ToList();
    }
}