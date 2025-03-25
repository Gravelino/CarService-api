using MediatR;

namespace Application.Features.Services.RestoreService;

public record RestoreServiceCommand(int Id): IRequest;