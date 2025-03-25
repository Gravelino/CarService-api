using MediatR;

namespace Application.Features.Services.UpdateService;

public record UpdateServiceCommand(int Id, string? ServiceName, string? Description,
    decimal? BasePrice, int? Duration, int? ServiceCategoryId): IRequest;