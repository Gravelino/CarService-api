using Application.Models;
using MediatR;

namespace Application.Features.JobSchedules.GetActiveJobSchedulesForWorker;

public record GetActiveJobSchedulesForWorkerQuery(int WorkerId) : IRequest<IEnumerable<JobSchedule>>;