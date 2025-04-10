using System.Windows.Input;
using MediatR;

namespace Application.Features.Jobs.RestoreJob;

public record RestoreJobCommand(int JobId) : IRequest;