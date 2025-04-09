using MediatR;

namespace Application.Features.Cars.CreateCar;

public record CreateCarCommand(string Brand, string Model, int Year, string LicensePlate, string Color, int CustomerId) : IRequest<int>;