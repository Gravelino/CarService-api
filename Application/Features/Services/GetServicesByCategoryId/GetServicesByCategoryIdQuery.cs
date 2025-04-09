using Application.Models;
using MediatR;

namespace Application.Features.Services.GetServicesByCategory;

public class GetServicesByCategoryIdQuery : IRequest<IEnumerable<Service>>
{
    public int Id { get; set; }
}