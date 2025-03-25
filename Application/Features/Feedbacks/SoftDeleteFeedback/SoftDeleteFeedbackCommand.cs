using MediatR;

namespace Application.Features.Feedbacks.SoftDeleteFeedback;

public record SoftDeleteFeedbackCommand(int Id) : IRequest;