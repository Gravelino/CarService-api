using Application.Models;
using MediatR;
using Persistence.Repositories.Interfaces;

namespace Application.Features.Feedbacks.CreateFeedback;

public class CreateFeedbackCommandHandler : IRequestHandler<CreateFeedbackCommand, int>
{
    private readonly IFeedbackRepository _feedbackRepository;

    public CreateFeedbackCommandHandler(IFeedbackRepository feedbackRepository)
    {
        _feedbackRepository = feedbackRepository;
    }
    
    public async Task<int> Handle(CreateFeedbackCommand request, CancellationToken cancellationToken)
    {
        var feedback = new Feedback
        {
            Rating = request.Rating,
            Comment = request.Comment,
            VisitId = request.VisitId,
            FeedbackDate = DateTime.UtcNow,
        };
        
        await _feedbackRepository.AddAsync(feedback);
        await _feedbackRepository.SaveChangesAsync();
        
        return feedback.Id;
    }
}