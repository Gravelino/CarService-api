using Application.Models;
using MediatR;

namespace Application.Features.JobSchedules.GetPlannedJobSchedulesForWorker;

public record GetPlannedJobSchedulesForWorkerQuery(int WorkerId): IRequest<IEnumerable<JobSchedule>>;