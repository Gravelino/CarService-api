using Application.DTOs;
using Application.Interfaces;
using Application.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Persistence.Repositories;

public class WorkerRepository : SoftDeletableRepository<Worker>, IWorkerRepository
{
    public WorkerRepository(CarServiceDbContext dbContext) : base(dbContext) { }

    public async Task<Worker?> GetWorkerWithScheduledVisitsByIdAsync(int workerId)
    {
        var worker = await _dbSet
            .Include(w => w.JobSchedules)
            .ThenInclude(js => js.Job)
            .ThenInclude(j => j.Visit.DeletedAt == null)
            .FirstOrDefaultAsync(m => m.Id == workerId && m.DeletedAt == null);

        return worker;
    }

    public async Task<IEnumerable<Worker>> GetAvailableWorkersAsync()
    {
        return await _dbSet
            .Where(m => m.DeletedAt == null && m.IsActive)
            .ToListAsync();
    }

    public async Task<bool> IsWorkerAvailableByIdAsync(int workerId, DateTime proposedStart, DateTime proposedEnd)
    {
        var hasConflict = await _context.JobSchedules.AnyAsync(schedule =>
            schedule.WorkerId == workerId &&
            proposedStart < schedule.EndDate &&
            proposedEnd > schedule.StartDate
        );
        
        return !hasConflict;
    }

    private async Task<IEnumerable<AvailableSlotDto>> FindFreeTimeSlots(
        List<AvailableSlotDto> busySlots,
        TimeSpan jobDuration,
        DateTime dayStart,
        DateTime dayEnd,
        int workerId,
        string workerName)
    {
        var freeSlots = new List<AvailableSlotDto>();
        DateTime currentTime = dayStart;

        foreach (var slot in busySlots)
        {
            if (slot.Start > currentTime)
            {
                if (slot.End - slot.Start >= jobDuration)
                {
                    freeSlots.Add(new AvailableSlotDto
                    {
                        Start = slot.Start,
                        End = slot.End,
                        WorkerId = workerId,
                        WorkerName = workerName,
                    });
                }
            }

            currentTime = slot.End > currentTime ? slot.End : currentTime;
        }

        if (currentTime < dayEnd && dayEnd - dayStart >= jobDuration)
        {
            freeSlots.Add(new AvailableSlotDto
            {
                Start = currentTime,
                End = dayEnd,
                WorkerId = workerId,
                WorkerName = workerName,
            });
        }
        
        return freeSlots;
    }

    public async Task<IEnumerable<AvailableSlotDto>> FindAvailableSlotsForService(int serviceId, DateTime startDate, DateTime endDate)
    {
        var service = await _context.Services.FindAsync(serviceId);
        if (service is null)
        {
            throw new KeyNotFoundException("Service not found");
        }
        
        TimeSpan jobDuration = TimeSpan.FromMinutes(service.Duration);
        
        var workerIds = await _context.WorkerServices
            .Where(ws => ws.ServiceId == serviceId)
            .Select(ws => ws.WorkerId)
            .ToListAsync();
        
        var freeSlots = new List<AvailableSlotDto>();

        foreach (var workerId in workerIds)
        {
            var worker = await _context.Workers.FindAsync(workerId);
            
            var busySlots = await _context.JobSchedules
                .Where(js => js.WorkerId == workerId &&
                             js.DeletedAt == null &&
                             js.StartDate < endDate &&
                             js.EndDate > startDate)
                .OrderBy(js => js.StartDate)
                .Select(js => new AvailableSlotDto { Start = js.StartDate, End = js.EndDate, WorkerId = workerId })
                .ToListAsync();
            
            DateTime currentDate = startDate.Date;
            DateTime endDateDay = endDate.Date;

            while (currentDate <= endDateDay)
            {
                DateTime dayStart = currentDate.AddHours(9);
                DateTime dayEnd = currentDate.AddHours(18);

                var dayBusySlots = busySlots
                    .Where(s => s.Start.Date == currentDate.Date && s.End.Date == currentDate.Date)
                    .OrderBy(s => s.Start)
                    .ToList();
                
                var dayFreeSlots = await FindFreeTimeSlots(dayBusySlots, jobDuration, dayStart, dayEnd,
                    workerId, $"{worker.FirstName} {worker.LastName}");
                
                freeSlots.AddRange(dayFreeSlots);
                
                currentDate = currentDate.AddDays(1);
            }
        }
        
        var nearestFreeSlots = freeSlots
            .OrderBy(s => s.Start)
            .Take(5)
            .ToList();
        
        return nearestFreeSlots;
    }
    
}