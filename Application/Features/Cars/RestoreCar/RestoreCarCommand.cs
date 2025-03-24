using MediatR;

namespace Application.Features.Cars.RestoreCar;

public record RestoreCarCommand(int Id) : IRequest<bool>;