using MediatR;
using Persistence.Repositories.Interfaces;

namespace Application.Features.Feedbacks.UpdateFeedback;

public class UpdateFeedbackCommandHandler : IRequestHandler<UpdateFeedbackCommand, bool>
{
    private readonly IFeedbackRepository _feedbackRepository;

    public UpdateFeedbackCommandHandler(IFeedbackRepository feedbackRepository)
    {
        _feedbackRepository = feedbackRepository;
    }
    
    public async Task<bool> Handle(UpdateFeedbackCommand request, CancellationToken cancellationToken)
    {
        var feedback = await _feedbackRepository.GetByIdAsync(request.Id);
        if (feedback == null)
        {
            return false;
        }
        
        if(request.Rating is not null) feedback.Rating = (int)request.Rating;
        if(request.Comment is not null) feedback.Comment = request.Comment;
        if(request.VisitId is not null) feedback.VisitId = (int)request.VisitId;

        _feedbackRepository.Update(feedback);
        await _feedbackRepository.SaveChangesAsync();
        
        return true;
    }
}