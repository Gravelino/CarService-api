using Application.Features.Jobs.CreateJob;
using Application.Features.Jobs.GetAllJobs;
using Application.Features.Jobs.GetAllJobsWithSchedules;
using Application.Features.Jobs.GetJobById;
using Application.Features.Jobs.GetJobsWithSchedulesByVisitId;
using Application.Features.Jobs.GetJobWithSchedule;
using Application.Features.Jobs.RestoreJob;
using Application.Features.Jobs.SoftDeleteJob;
using Application.Features.Jobs.UpdateJob;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobsController : Controller
{
    private readonly IMediator _mediator;

    public JobsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllJobs(
        [FromQuery] int page = 1,
        [FromQuery] int perPage = 10,
        [FromQuery] string sort = "Id",
        [FromQuery] string order = "ASC",
        [FromQuery] string? nameLike = null)
    {
        var query = new GetAllJobsQuery
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
    public async Task<IActionResult> GetJobById(int id)
    {
        var job = await _mediator.Send(new GetJobByIdQuery(id));
        if(job == null)
            return NotFound();
        
        return Ok(new { data = job });
    }

    [HttpPost]
    public async Task<IActionResult> CreateJob([FromBody] CreateJobCommand command)
    {
        var jobId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetJobById), new { id = jobId}, jobId);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateJob(int id, [FromBody] UpdateJobCommand command)
    {
        if(id != command.JobId)
            return BadRequest();
        
        await _mediator.Send(command);
        return NoContent();
    }
    
    [HttpPut("{id:int}/softDelete")]
    public async Task<IActionResult> DeleteJob(int id)
    {
        await _mediator.Send(new SoftDeleteJobCommand(id));
        return NoContent();
    }

    [HttpPut("{id:int}/restore")]
    public async Task<IActionResult> RestoreJob(int id)
    {
        await _mediator.Send(new RestoreJobCommand(id));
        return NoContent();
    }

    [HttpGet("get-with-schedule/{id:int}")]
    public async Task<IActionResult> GetJobWithScheduleById(int id)
    {
        var job = await _mediator.Send(new GetJobWithScheduleQuery(id));
        if(job == null)
            return NotFound();
        
        return Ok(new { data = job });
    }

    [HttpGet("get-with-schedules-by-visitsId/{visitId:int}")]
    public async Task<IActionResult> GetJobsWithSchedulesByVisitsId(int visitId)
    {
        var jobs = await _mediator.Send(new GetJobsWithSchedulesByVisitIdQuery(visitId));
        return Ok(new { data = jobs });
    }

    [HttpGet("get-all-with-schedules")]
    public async Task<IActionResult> GetAllJobsWithSchedules()
    {
        var jobs = await _mediator.Send(new GetAllJobsWithSchedulesQuery());
        return Ok(new { data = jobs });
    }
}