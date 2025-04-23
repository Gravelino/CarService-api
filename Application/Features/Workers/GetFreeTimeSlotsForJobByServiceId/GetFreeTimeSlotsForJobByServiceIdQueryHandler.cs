using Application.DTOs;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Workers.GetFreeTimeSlotsForJobByServiceId;

public class GetFreeTimeSlotsForJobByServiceIdQueryHandler : IRequestHandler<GetFreeTimeSlotsForJobByServiceIdQuery, IEnumerable<AvailableSlotDto>>
{
    private readonly IWorkerRepository _workerRepository;

    public GetFreeTimeSlotsForJobByServiceIdQueryHandler(IWorkerRepository workerRepository)
    {
        _workerRepository = workerRepository;
    }

    public async Task<IEnumerable<AvailableSlotDto>> Handle(GetFreeTimeSlotsForJobByServiceIdQuery request, CancellationToken cancellationToken)
    {
        var freeTimeSlots = await _workerRepository.FindAvailableSlotsForService(request.ServiceId, request.StartDate, request.EndDate);
        return freeTimeSlots;
    }
}