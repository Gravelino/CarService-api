using Application.Models;
using MediatR;
using Persistence.Repositories.Interfaces;

namespace Application.Features.Tools.GetToolBySerialNumber;

public class GetToolBySerialNumberQueryHandler : IRequestHandler<GetToolBySerialNumberQuery, Tool?>
{
    private readonly IToolRepository _repository;

    public GetToolBySerialNumberQueryHandler(IToolRepository repository)
    {
        _repository = repository;
    }

    public async Task<Tool?> Handle(GetToolBySerialNumberQuery request, CancellationToken cancellationToken)
    {
        var tool = await _repository.GetToolBySerialNumberAsync(request.SerialNumber);
        return tool;
    }
}