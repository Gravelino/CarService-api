using Application.Models;
using MediatR;

namespace Application.Features.Cars.GetAllCars;

public class GetAllCarsQuery : IRequest<IEnumerable<Car>>
{
    
}