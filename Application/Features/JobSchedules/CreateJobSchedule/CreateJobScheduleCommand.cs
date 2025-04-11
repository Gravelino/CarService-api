using MediatR;

namespace Application.Features.JobSchedules.CreateJobSchedule;

public record CreateJobScheduleCommand(DateTime StartDate, DateTime EndDate, int JobId, int WorkerId) : IRequest<int>;