using Application.Interfaces;
using MediatR;

namespace Application.Features.Visits.RestoreVisit;

public class RestoreVisitCommandHandler : IRequestHandler<RestoreVisitCommand>
{
    private readonly IVisitRepository _visitRepository;

    public RestoreVisitCommandHandler(IVisitRepository visitRepository)
    {
        _visitRepository = visitRepository;
    }
    
    public async Task Handle(RestoreVisitCommand request, CancellationToken cancellationToken)
    {
        var visit = await _visitRepository.GetByIdAsync(request.Id);
        if (visit == null)
        {
            throw new Exception("Visit not found");
        }
        
        await _visitRepository.RestoreAsync(visit.Id);
    }
}