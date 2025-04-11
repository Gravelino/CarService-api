using Application.Features.JobSchedules.CreateJobSchedule;
using Application.Features.JobSchedules.GetActiveJobSchedulesForWorker;
using Application.Features.JobSchedules.GetAllJobSchedules;
using Application.Features.JobSchedules.GetAllJobSchedulesForWorker;
using Application.Features.JobSchedules.GetJobScheduleById;
using Application.Features.JobSchedules.GetPlannedJobSchedulesForWorker;
using Application.Features.JobSchedules.RestoreJobSchedule;
using Application.Features.JobSchedules.SoftDeleteJobSchedule;
using Application.Features.JobSchedules.UpdateJobSchedule;
using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobSchedulesController : Controller
{
    private readonly IMediator _mediator;

    public JobSchedulesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllJobSchedules(
        [FromQuery] int page = 1,
        [FromQuery] int perPage = 10,
        [FromQuery] string sort = "Id",
        [FromQuery] string order = "ASC",
        [FromQuery] string? nameLike = null)
    {
        var query = new GetAllJobSchedulesQuery
        {
            Page = page,
            PageSize = perPage,
            SortField = sort,
            SortOrder = order,
            NameFilter = nameLike,
        };
        
        var result = await _mediator.Send(query);
        return Ok(new { data = result.Items, total = result.TotalCount});
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetJobScheduleById(int id)
    {
        var jobSchedule = await _mediator.Send(new GetJobScheduleByIdQuery(id));
        if(jobSchedule == null)
            return NotFound();
        
        return Ok(new {data = jobSchedule});
    }

    [HttpPost]
    public async Task<IActionResult> CreateJobSchedule([FromBody] CreateJobScheduleCommand command)
    {
        var jobScheduleId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetJobScheduleById), new {id = jobScheduleId}, jobScheduleId);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateJobSchedule(int id, [FromBody] UpdateJobScheduleCommand command)
    {
        if(id != command.JobScheduleId)
            return BadRequest();
        
        await _mediator.Send(command);
        return NoContent();
    }
    
    [HttpPut("{id:int}/softDelete")]
    public async Task<IActionResult> DeleteJobSchedule(int id)
    {
        await _mediator.Send(new SoftDeleteJobScheduleCommand(id));
        return NoContent();
    }

    [HttpPut("{id:int}/restore")]
    public async Task<IActionResult> RestoreJobSchedule(int id)
    {
        await _mediator.Send(new RestoreJobScheduleCommand(id));
        return NoContent();
    }
    
    [HttpGet("get-all-schedules-by-workerId/{workerId:int}")]
    public async Task<IActionResult> GetAllJobSchedulesByWorkerId(int workerId)
    {
        var jobSchedules = await _mediator.Send(new GetAllJobSchedulesForWorkerQuery(workerId));
        return Ok(new { data = jobSchedules });
    }

    [HttpGet("get-active-schedules-by-workerId/{workerId:int}")]
    public async Task<IActionResult> GetActiveJobSchedulesByWorkerId(int workerId)
    {
        var jobSchedules = await _mediator.Send(new GetActiveJobSchedulesForWorkerQuery(workerId));
        return Ok(new { data = jobSchedules });
    }

    [HttpGet("get-planned-schedules-by-workerId/{workerId:int}")]
    public async Task<IActionResult> GetPlannedJobSchedulesByWorkerId(int workerId)
    {
        var jobSchedules = await _mediator.Send(new GetPlannedJobSchedulesForWorkerQuery(workerId));
        return Ok(new { data = jobSchedules });
    }
}