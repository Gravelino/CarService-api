using MediatR;

namespace Application.Features.Feedbacks.RestoreFeedback;

public record RestoreFeedbackCommand(int Id) : IRequest<bool>;