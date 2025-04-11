using Application.Models;
using MediatR;

namespace Application.Features.JobSchedules.GetJobScheduleById;

public record GetJobScheduleByIdQuery(int Id) : IRequest<JobSchedule?>;