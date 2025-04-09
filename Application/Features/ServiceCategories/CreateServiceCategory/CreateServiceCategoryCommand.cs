using Application.Models;
using MediatR;

namespace Application.Features.Services.CreateService;

public record CreateServiceCategoryCommand(string CategoryName, string Description): IRequest<int>;