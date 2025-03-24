using Application.Models;
using MediatR;

namespace Application.Features.Services.GetAllServices;

public class GetAllServicesQuery : IRequest<IEnumerable<Service>>
{
    
}