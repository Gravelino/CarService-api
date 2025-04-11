using MediatR;

namespace Application.Features.JobSchedules.UpdateJobSchedule;

public record UpdateJobScheduleCommand(int JobScheduleId, DateTime? StartDate, DateTime? EndDate,int? JobId, int? WorkerId) : IRequest;