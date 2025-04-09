using Application.Features.Tools.UpdateTool;
using Application.Features.Visits.UpdateVisit;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Visits.UpdateVisit;

public class UpdateVisitCommandHandler : IRequestHandler<UpdateVisitCommand>
{
    private readonly IVisitRepository _visitRepository;

    public UpdateVisitCommandHandler(IVisitRepository visitRepository)
    {
        _visitRepository = visitRepository;
    }
    
    public async Task Handle(UpdateVisitCommand request, CancellationToken cancellationToken)
    {
        var visit = await _visitRepository.GetByIdAsync(request.Id);
        if (visit == null)
        {
            throw new Exception("Visit not found");
        }
        
        if(request.VisitStartDate is not null) visit.VisitStartDate = (DateTime)request.VisitStartDate;
        if(request.VisitEndDate is not null) visit.VisitEndDate = (DateTime)request.VisitEndDate;
        if(request.Status is not null) visit.Status = request.Status;
        if(request.TotalPrice.HasValue) visit.TotalPrice = request.TotalPrice.Value;
        if(request.CustomerId.HasValue) visit.CustomerId = request.CustomerId.Value;
        if(request.CarId.HasValue) visit.CarId = request.CarId.Value;
        
        await _visitRepository.Update(visit);
        await _visitRepository.SaveChangesAsync();
    }
}