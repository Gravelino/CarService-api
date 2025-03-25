using Application.Features.Visits.SoftDeleteVisit;
using MediatR;
using Persistence.Repositories.Interfaces;

namespace Application.Features.Visits.SoftDeleteVisit;

public class SoftDeleteVisitCommandHandler : IRequestHandler<SoftDeleteVisitCommand>
{
    private readonly IVisitRepository _visitRepository;

    public SoftDeleteVisitCommandHandler(IVisitRepository visitRepository)
    {
        _visitRepository = visitRepository;
    }
    
    public async Task Handle(SoftDeleteVisitCommand request, CancellationToken cancellationToken)
    {
        var visit = await _visitRepository.GetByIdAsync(request.Id);
        if (visit == null)
        {
            throw new Exception("Visit not found");
        }
        
        await _visitRepository.SoftDeleteAsync(visit.Id);
    }
}