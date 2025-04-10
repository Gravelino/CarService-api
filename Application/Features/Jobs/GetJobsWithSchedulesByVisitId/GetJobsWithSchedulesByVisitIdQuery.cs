using Application.Models;
using MediatR;

namespace Application.Features.Jobs.GetJobsWithSchedulesByVisitId;

public record GetJobsWithSchedulesByVisitIdQuery(int VisitId): IRequest<IEnumerable<Job>>;