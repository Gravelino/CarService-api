using Application.Models;
using MediatR;

namespace Application.Features.Workers.GetWorkerById;

public class GetWorkerByIdQuery : IRequest<Worker?>
{
    public int WorkerId { get; set; }
}