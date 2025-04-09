using Application.Features.Visits.CreateVisit;
using Application.Interfaces;
using Application.Models;
using MediatR;

namespace Application.Features.Visits.CreateVisit;

public class CreateVisitCommandHandler : IRequestHandler<CreateVisitCommand, int>
{
    private readonly IVisitRepository _visitRepository;

    public CreateVisitCommandHandler(IVisitRepository visitRepository)
    {
        _visitRepository = visitRepository;
    }
    
    public async Task<int> Handle(CreateVisitCommand request, CancellationToken cancellationToken)
    {
        var visit = new Visit
        {
            VisitStartDate = request.VisitStartDate,
            VisitEndDate = request.VisitEndDate,
            Status = request.Status,
            TotalPrice = request.TotalPrice,
            CustomerId = request.CustomerId,
            CarId = request.CarId
        };
        
        await _visitRepository.AddAsync(visit);
        await _visitRepository.SaveChangesAsync();
        
        return visit.Id;
    }
}