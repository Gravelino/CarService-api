using Application.Models;
using MediatR;

namespace Application.Features.Feedbacks.GetFeedbackByVisit;

public class GetFeedbackByVisitQuery : IRequest<IEnumerable<Feedback>>
{
    public int VisitId { get; set; }
}