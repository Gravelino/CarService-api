using MediatR;

namespace Application.Features.JobSchedules.SoftDeleteJobSchedule;

public record SoftDeleteJobScheduleCommand(int JobId) : IRequest;