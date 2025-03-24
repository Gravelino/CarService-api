using MediatR;

namespace Application.Features.Cars.SoftDeleteCar;

public record SoftDeleteCarCommand(int Id) : IRequest<bool>;