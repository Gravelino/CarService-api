using Application.Features.Visits.CreateVisit;
using Application.Features.Visits.GetAllVisits;
using Application.Features.Visits.GetVisitById;
using Application.Features.Visits.GetVisitsByCustomerId;
using Application.Features.Visits.GetVisitsWithPayments;
using Application.Features.Visits.GetVisitWithServicesAndWorkersById;
using Application.Features.Visits.RestoreVisit;
using Application.Features.Visits.SoftDeleteVisit;
using Application.Features.Visits.UpdateVisit;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VisitsController : Controller
{
    private readonly IMediator _mediator;
    
    public VisitsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllVisits(
        [FromQuery] int page = 1,
        [FromQuery] int perPage = 10,
        [FromQuery] string sort = "Id",
        [FromQuery] string order = "ASC",
        [FromQuery] string? nameLike = null)
    {
        var query = new GetAllVisitsQuery
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
    public async Task<IActionResult> GetVisitById(int id)
    {
        var visit = await _mediator.Send(new GetVisitByIdQuery{ Id = id });
        if (visit == null)
            return NotFound();
        
        return Ok(new { data = visit });
    }

    [HttpPost]
    public async Task<IActionResult> CreateVisit([FromBody] CreateVisitCommand command)
    {
        var visitId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetVisitById), new {id = visitId}, visitId);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateVisit(int id, 
        [FromBody] UpdateVisitCommand command)
    {
        if(id != command.Id)
            return BadRequest();
        
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpPut("{id:int}/softDelete")]
    public async Task<IActionResult> DeleteVisit(int id)
    {
        await _mediator.Send(new SoftDeleteVisitCommand(id));
        return NoContent();
    }

    [HttpPut("{id:int}/restore")]
    public async Task<IActionResult> RestoreVisit(int id)
    {
        await _mediator.Send(new RestoreVisitCommand(id));
        return NoContent();
    }

    [HttpGet("get-by-customerId/{id:int}")]
    public async Task<IActionResult> GetVisitsByCustomerId(int id)
    {
        var visits = await _mediator.Send(new GetVisitsByCustomerIdQuery{ Id = id });
        if(visits == null || visits.Count() == 0)
            return NotFound();
        
        return Ok(new { data = visits });
    }

    [HttpGet("get-with-payments")]
    public async Task<IActionResult> GetVisitsWithPayments()
    {
        var visits = await _mediator.Send(new GetVisitsWithPaymentsQuery());
        return Ok(new {data = visits});
    }

    [HttpGet("get-with-services-and-workers-by-id/{id:int}")]
    public async Task<IActionResult> GetVisitsWithServicesAndWorkers(int id)
    {
        var visit = await _mediator.Send(new GetVisitWithServicesAndWorkersByIdQuery { VisitId = id });
        if(visit == null)
            return NotFound();
        
        return Ok(new  { data = visit});
    }
}