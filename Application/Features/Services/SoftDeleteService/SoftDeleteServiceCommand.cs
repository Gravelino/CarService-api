using MediatR;

namespace Application.Features.Services.SoftDeleteService;

public record SoftDeleteServiceCommand(int Id) : IRequest;