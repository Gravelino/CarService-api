using Application.Models;
using MediatR;

namespace Application.Features.Cars.GetCarById;

public class GetCarByIdQuery : IRequest<Car?>
{
    public int CarId { get; set; }
}