using MediatR;

namespace Application.Features.Feedbacks.CreateFeedback;

public record CreateFeedbackCommand(int Rating,  string Comment, int VisitId) : IRequest<int>;