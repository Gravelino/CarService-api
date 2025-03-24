using Application.Models;
using MediatR;

namespace Application.Features.Tools.GetToolBySerialNumber;

public class GetToolBySerialNumberQuery : IRequest<Tool?>
{
    public int SerialNumber { get; set; }
}