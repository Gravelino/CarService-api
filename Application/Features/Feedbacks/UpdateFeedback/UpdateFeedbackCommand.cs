using MediatR;

namespace Application.Features.Feedbacks.UpdateFeedback;

public record UpdateFeedbackCommand(int Id, int? Rating,  string? Comment, int? VisitId) : IRequest<bool>;