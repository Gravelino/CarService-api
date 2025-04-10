using Application.Models;
using MediatR;

namespace Application.Features.Jobs.GetAllJobsWithSchedules;

public record GetAllJobsWithSchedulesQuery : IRequest<IEnumerable<Job>>;