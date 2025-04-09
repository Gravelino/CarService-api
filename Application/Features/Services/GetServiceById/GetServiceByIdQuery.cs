using Application.Models;
using MediatR;

namespace Application.Features.Services.GetServiceById;

public class GetServiceByIdQuery : IRequest<Service?>
{
    public int ServiceId { get; set; }
}