using Application.Models;
using MediatR;

namespace Application.Features.Jobs.GetJobById;

public record GetJobByIdQuery(int JobId) : IRequest<Job?>;