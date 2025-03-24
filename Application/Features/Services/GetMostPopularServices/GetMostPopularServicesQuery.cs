using Application.Models;
using MediatR;

namespace Application.Features.Services.GetMostPopularServices;

public class GetMostPopularServicesQuery : IRequest<IEnumerable<Service>>
{
    public int Limit { get; set; }
}