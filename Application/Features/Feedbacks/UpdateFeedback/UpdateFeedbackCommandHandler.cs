using MediatR;
using Persistence.Repositories.Interfaces;

namespace Application.Features.Feedbacks.UpdateFeedback;

public class UpdateFeedbackCommandHandler : IRequestHandler<UpdateFeedbackCommand>
{
    private readonly IFeedbackRepository _feedbackRepository;

    public UpdateFeedbackCommandHandler(IFeedbackRepository feedbackRepository)
    {
        _feedbackRepository = feedbackRepository;
    }
    
    public async Task Handle(UpdateFeedbackCommand request, CancellationToken cancellationToken)
    {
        var feedback = await _feedbackRepository.GetByIdAsync(request.Id);
        if (feedback == null)
        {
            throw new Exception("Feedback not found");
        }
        
        if(request.Rating is not null) feedback.Rating = (int)request.Rating;
        if(request.Comment is not null) feedback.Comment = request.Comment;

        _feedbackRepository.Update(feedback);
        await _feedbackRepository.SaveChangesAsync();
    }
}