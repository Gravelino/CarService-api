using Application.Features.Services.CreateService;
using Application.Features.Services.GetAllServices;
using Application.Features.Services.GetMostPopularServices;
using Application.Features.Services.GetServiceById;
using Application.Features.Services.GetServicesByCategory;
using Application.Features.Services.RestoreService;
using Application.Features.Services.SoftDeleteService;
using Application.Features.Services.UpdateService;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServicesController : Controller
{
    private readonly IMediator _mediator;

    public ServicesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllServices(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] string sort = "Id",
        [FromQuery] string order = "ASC",
        [FromQuery] string? NameFilter = null,
        [FromQuery] string? DescriptionFilter = null)
    {
        try
        {
            var query = new GetAllServicesQuery
            {
                Page = page,
                PageSize = pageSize,
                SortField = sort,
                SortOrder = order,
                NameFilter = NameFilter,
                DescriptionFilter = DescriptionFilter
            };
        
            var result = await _mediator.Send(query);
        
            return Ok(new { data = result.Items, total = result.TotalCount});
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetServiceById(int id)
    {
        var service = await _mediator.Send(new GetServiceByIdQuery{ServiceId = id});
        if(service == null)
            return NotFound();
        
        return Ok(new {data = service});
    }

    [HttpPost]
    public async Task<IActionResult> CreateService([FromBody] CreateServiceCommand command)
    {
        var serviceId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetServiceById), new { id = serviceId }, serviceId);
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateService(int id, 
        [FromBody] UpdateServiceCommand command)
    {
        if(id != command.Id)
            return BadRequest();
        
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpPut("{id:int}/softDelete")]
    public async Task<IActionResult> DeleteService(int id)
    {
        await _mediator.Send(new SoftDeleteServiceCommand(id));
        return NoContent();
    }

    [HttpPut("{id:int}/restore")]
    public async Task<IActionResult> RestoreService(int id)
    {
        await _mediator.Send(new RestoreServiceCommand(id));
        return NoContent();
    }

    [HttpGet("get-most-popular/{limit:int}")]
    public async Task<IActionResult> GetMostPopularService(int limit)
    {
        var services = await _mediator.Send(new GetMostPopularServicesQuery{Limit = limit});
        return Ok(new { data = services});
    }

    [HttpGet("get-services-by-categoryId/{categoryId:int}")]
    public async Task<IActionResult> GetServicesByCategoryId(int categoryId)
    {
        var services = await _mediator.Send(new GetServicesByCategoryIdQuery{Id = categoryId});
        if(services == null)
            return NotFound();
        
        return Ok(new { data = services });
    }
}