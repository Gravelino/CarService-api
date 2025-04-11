using Application.Features.Workers.CreateWorker;
using Application.Features.Workers.GetAllWorkers;
using Application.Features.Workers.GetAvailableWorkers;
using Application.Features.Workers.GetIfWorkerAvailableForJob;
using Application.Features.Workers.GetWorkerById;
using Application.Features.Workers.GetWorkerWithScheduledVisitsById;
using Application.Features.Workers.RestoreWorker;
using Application.Features.Workers.SoftDeleteWorker;
using Application.Features.Workers.UpdateWorker;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WorkersController : Controller
{
    private readonly IMediator _mediator;

    public WorkersController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllWorkers(
        [FromQuery] int page = 1,
        [FromQuery] int perPage = 10,
        [FromQuery] string sort = "Id",
        [FromQuery] string order = "ASC",
        [FromQuery] string? nameLike = null)
    {
        var query = new GetAllWorkersQuery
        {
            Page = page,
            PageSize = perPage,
            SortField = sort,
            SortOrder = order,
            NameFilter = nameLike,
        };
        
        var result = await _mediator.Send(query);
        
        //Response.Headers.Add("Content-Range", $"customers {0}-{0 + customers.Count() - 1}/{customers.Count()}");
        //Response.Headers.Add("Access-Control-Expose-Headers", "Content-Range");
        
        return Ok(new { data = result.Items, total = result.TotalCount});
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetWorkerById(int id)
    {
        var worker = await _mediator.Send(new GetWorkerByIdQuery{ WorkerId = id });
        if (worker == null)
            return NotFound();
        
        return Ok(new { data = worker});
    }

    [HttpPost]
    public async Task<IActionResult> CreateWorker([FromBody] CreateWorkerCommand command)
    {
        var workerId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetWorkerById), new {id = workerId}, workerId);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateWorker(int id, 
        [FromBody] UpdateWorkerCommand command)
    {
        if(id != command.Id)
            return BadRequest();
        
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpPut("{id:int}/softDelete")]
    public async Task<IActionResult> DeleteWorker(int id)
    {
        await _mediator.Send(new SoftDeleteWorkerCommand(id));
        return NoContent();
    }

    [HttpPut("{id:int}/restore")]
    public async Task<IActionResult> RestoreWorker(int id)
    {
        await _mediator.Send(new RestoreWorkerCommand(id));
        return NoContent();
    }

    [HttpGet("get-available")]
    public async Task<IActionResult> GetAvailableWorkers()
    {
        var workers = await _mediator.Send(new GetAvailableWorkersQuery());
        if(workers == null || workers.Count() == 0)
            return NotFound();
        
        return Ok(new { data = workers});
    }

    [HttpGet("get-with-scheduled-visits-by-id/{id:int}")]
    public async Task<IActionResult> GetWithScheduledVisitsByWorkerId(int id)
    {
        var worker = await _mediator.Send(new GetWorkerWithScheduledVisitsByIdQuery { WorkerId = id });
        if (worker == null)
            return NotFound();

        return Ok(new {data = worker });
    }

    [HttpGet("get-if-available-for-job/{workerId:int}")]
    public async Task<IActionResult> GetIfAvailableForJob(int workerId, DateTime startDate, DateTime endDate)
    {
        var isAvailable = await _mediator.Send(new GetIfWorkerAvailableForJobQuery(workerId, startDate, endDate));
        return Ok(isAvailable);
    }
}