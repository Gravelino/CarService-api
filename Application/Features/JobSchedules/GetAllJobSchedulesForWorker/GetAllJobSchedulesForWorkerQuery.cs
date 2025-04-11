using Application.Models;
using MediatR;

namespace Application.Features.JobSchedules.GetAllJobSchedulesForWorker;

public record GetAllJobSchedulesForWorkerQuery(int WorkerId) : IRequest<IEnumerable<JobSchedule>>;