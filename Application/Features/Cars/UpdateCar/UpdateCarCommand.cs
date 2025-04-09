using MediatR;

namespace Application.Features.Cars.UpdateCar;

public record UpdateCarCommand(int Id, string? Brand, string? Model,
    int? Year, string? LicensePlate, string? Color, int? CustomerId) : IRequest;