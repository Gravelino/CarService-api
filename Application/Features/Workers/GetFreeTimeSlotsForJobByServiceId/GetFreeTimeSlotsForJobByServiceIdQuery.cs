using Application.DTOs;
using MediatR;

namespace Application.Features.Workers.GetFreeTimeSlotsForJobByServiceId;

public record GetFreeTimeSlotsForJobByServiceIdQuery(int ServiceId, DateTime StartDate, DateTime EndDate) : IRequest<IEnumerable<AvailableSlotDto>>;