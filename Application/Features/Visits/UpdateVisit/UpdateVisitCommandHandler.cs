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
        if(request.TotalPrice is not null) visit.TotalPrice = (decimal)request.TotalPrice;
        if(request.CustomerId is not null) visit.CustomerId = (int)request.CustomerId;
        if(request.CarId is not null) visit.CarId = (int)request.CarId;
        
        _visitRepository.Update(visit);
        await _visitRepository.SaveChangesAsync();
    }
}