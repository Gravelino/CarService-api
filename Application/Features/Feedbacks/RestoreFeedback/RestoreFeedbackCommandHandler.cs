using MediatR;
using Persistence.Repositories.Interfaces;

namespace Application.Features.Feedbacks.RestoreFeedback;

public class RestoreFeedbackCommandHandler : IRequestHandler<RestoreFeedbackCommand, bool>
{
    private readonly IFeedbackRepository _feedbackRepository;

    public RestoreFeedbackCommandHandler(IFeedbackRepository feedbackRepository)
    {
        _feedbackRepository = feedbackRepository;
    }
    
    public async Task<bool> Handle(RestoreFeedbackCommand request, CancellationToken cancellationToken)
    {
        var feedback = await _feedbackRepository.GetByIdAsync(request.Id);
        if (feedback == null)
        {
            return false;
        }
        
        await _feedbackRepository.RestoreAsync(feedback.Id);
        
        return true;
    }
}