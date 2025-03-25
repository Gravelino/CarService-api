using Application.Models;
using MediatR;

namespace Application.Features.Services.CreateService;

public record CreateServiceCommand(string ServiceName, string Description,
    decimal BasePrice, int Duration, int ServiceCategoryId): IRequest<int>;