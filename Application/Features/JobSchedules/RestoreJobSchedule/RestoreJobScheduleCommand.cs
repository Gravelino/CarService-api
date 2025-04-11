using System.Windows.Input;
using MediatR;

namespace Application.Features.JobSchedules.RestoreJobSchedule;

public record RestoreJobScheduleCommand(int JobId) : IRequest;