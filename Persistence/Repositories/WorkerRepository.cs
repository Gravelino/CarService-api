﻿using Application.DTOs;
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

    private List<AvailableSlotDto> FindFreeTimeSlots(
        List<AvailableSlotDto> busySlots,
        TimeSpan jobDuration,
        DateTime dayStart,
        DateTime dayEnd,
        int workerId,
        string workerName)
    {
        var freeSlots = new List<AvailableSlotDto>();
        var currentTime = dayStart;

        foreach (var slot in busySlots)
        {
            if (slot.Start > currentTime && slot.End - slot.Start >= jobDuration)
            {
                freeSlots.Add(new AvailableSlotDto
                {
                    Start = slot.Start,
                    End = slot.End,
                    WorkerId = workerId,
                    WorkerName = workerName,
                });
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

    private async Task<List<AvailableSlotDto>> GetBusySlotsByWorkerId(int workerId, DateTime startDate, DateTime endDate)
    {
        return await _context.JobSchedules
            .Where(js => js.WorkerId == workerId &&
                         js.DeletedAt == null &&
                         js.StartDate < endDate &&
                         js.EndDate > startDate)
            .OrderBy(js => js.StartDate)
            .Select(js => new AvailableSlotDto { Start = js.StartDate, End = js.EndDate, WorkerId = workerId })
            .ToListAsync();
    }
    
    private List<AvailableSlotDto> GetBusySlotsByDate(List<AvailableSlotDto> busySlots, DateTime date)
    {
        return busySlots
            .Where(s => s.Start.Date == date.Date && s.End.Date == date.Date)
            .OrderBy(s => s.Start)
            .ToList();
    }

    private async Task<List<int>> GetWorkerIdsByServiceId(int serviceId)
    {
        return await _context.WorkerServices
            .Where(ws => ws.ServiceId == serviceId)
            .Select(ws => ws.WorkerId)
            .ToListAsync();
    }
    
    public async Task<IEnumerable<AvailableSlotDto>> FindAvailableSlotsForService(
        int serviceId,
        DateTime startDate,
        DateTime endDate)
    {
        var service = await _context.Services.FindAsync(serviceId);
        if (service is null)
        {
            throw new KeyNotFoundException("Service not found");
        }
        
        var jobDuration = TimeSpan.FromMinutes(service.Duration);
        var workerIds = await GetWorkerIdsByServiceId(serviceId);
        var freeSlots = new List<AvailableSlotDto>();

        foreach (var workerId in workerIds)
        {
            var worker = await _context.Workers.FindAsync(workerId);

            var busySlots = await GetBusySlotsByWorkerId(workerId, startDate, endDate);
            
            var currentDate = startDate.Date;
            var endDateDay = endDate.Date;

            while (currentDate <= endDateDay)
            {
                var dayStart = currentDate.AddHours(9);
                var dayEnd = currentDate.AddHours(18);

                var dayBusySlots = GetBusySlotsByDate(busySlots, currentDate);
                
                var dayFreeSlots = FindFreeTimeSlots(dayBusySlots, jobDuration, dayStart, dayEnd,
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