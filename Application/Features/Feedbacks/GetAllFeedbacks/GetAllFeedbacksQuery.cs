using Application.Models;
using MediatR;

namespace Application.Features.Feedbacks.GetAllFeedbacks;

public class GetAllFeedbacksQuery : IRequest<IEnumerable<Feedback>>
{
    
}