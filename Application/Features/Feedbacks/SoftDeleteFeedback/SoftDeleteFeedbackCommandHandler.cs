using MediatR;
using Persistence.Repositories.Interfaces;

namespace Application.Features.Feedbacks.SoftDeleteFeedback;

public class SoftDeleteFeedbackCommandHandler : IRequestHandler<SoftDeleteFeedbackCommand>
{
    private readonly IFeedbackRepository _feedbackRepository;

    public SoftDeleteFeedbackCommandHandler(IFeedbackRepository feedbackRepository)
    {
        _feedbackRepository = feedbackRepository;
    }
    
    public async Task Handle(SoftDeleteFeedbackCommand request, CancellationToken cancellationToken)
    {
        var feedback = await _feedbackRepository.GetByIdAsync(request.Id);
        if (feedback == null)
        {
            throw new Exception("Feedback not found");
        }
        
        await _feedbackRepository.SoftDeleteAsync(feedback.Id);
    }
}