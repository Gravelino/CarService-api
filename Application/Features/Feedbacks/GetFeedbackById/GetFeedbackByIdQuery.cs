using Application.Models;
using MediatR;

namespace Application.Features.Feedbacks.GetFeedbackById;

public class GetFeedbackByIdQuery : IRequest<Feedback?>
{
    public int FeedbackId { get; set; }
}