using Application.Models;
using MediatR;

namespace Application.Features.Jobs.GetJobWithSchedule;

public record GetJobWithScheduleQuery(int JobId) : IRequest<Job?>;