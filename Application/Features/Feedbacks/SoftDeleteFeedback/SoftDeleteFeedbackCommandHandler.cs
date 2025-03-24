using MediatR;
using Persistence.Repositories.Interfaces;

namespace Application.Features.Feedbacks.SoftDeleteFeedback;

public class SoftDeleteFeedbackCommandHandler : IRequestHandler<SoftDeleteFeedbackCommand, bool>
{
    private readonly IFeedbackRepository _feedbackRepository;

    public SoftDeleteFeedbackCommandHandler(IFeedbackRepository feedbackRepository)
    {
        _feedbackRepository = feedbackRepository;
    }
    
    public async Task<bool> Handle(SoftDeleteFeedbackCommand request, CancellationToken cancellationToken)
    {
        var feedback = await _feedbackRepository.GetByIdAsync(request.Id);
        if (feedback == null)
        {
            return false;
        }
        
        await _feedbackRepository.SoftDeleteAsync(feedback.Id);
        
        return true;
    }
}