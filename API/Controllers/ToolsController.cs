using Application.Features.Tools.CreateTool;
using Application.Features.Tools.GetAllTools;
using Application.Features.Tools.GetToolById;
using Application.Features.Tools.GetToolBySerialNumber;
using Application.Features.Tools.GetToolsForService;
using Application.Features.Tools.RestoreTool;
using Application.Features.Tools.SoftDeleteTool;
using Application.Features.Tools.UpdateTool;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ToolsController : Controller
{
    private readonly IMediator _mediator;
    
    public ToolsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllTools(
        [FromQuery] int page = 1,
        [FromQuery] int perPage = 10,
        [FromQuery] string sort = "Id",
        [FromQuery] string order = "ASC",
        [FromQuery] string? nameLike = null,
        [FromQuery] string? descriptionLike = null)
    {
        var query = new GetAllToolsQuery
        {
            Page = page,
            PageSize = perPage,
            SortField = sort,
            SortOrder = order,
            NameFilter = nameLike,
            DescriptionFilter = descriptionLike
        };
        
        var result = await _mediator.Send(query);
        
        //Response.Headers.Add("Content-Range", $"customers {0}-{0 + customers.Count() - 1}/{customers.Count()}");
        //Response.Headers.Add("Access-Control-Expose-Headers", "Content-Range");
        
        return Ok(new { data = result.Items, total = result.TotalCount});
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetToolById(int id)
    {
        var tool = await _mediator.Send(new GetToolByIdQuery{ ToolId = id });
        if (tool == null)
            return NotFound();
        
        return Ok(new { data = tool });
    }

    [HttpPost]
    public async Task<IActionResult> CreateTool([FromBody] CreateToolCommand command)
    {
        var toolId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetToolById), new {id = toolId}, toolId);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateTool(int id, 
        [FromBody] UpdateToolCommand command)
    {
        if(id != command.Id)
            return BadRequest();
        
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpPut("{id:int}/softDelete")]
    public async Task<IActionResult> DeleteTool(int id)
    {
        await _mediator.Send(new SoftDeleteToolCommand(id));
        return NoContent();
    }

    [HttpPut("{id:int}/restore")]
    public async Task<IActionResult> RestoreTool(int id)
    {
        await _mediator.Send(new RestoreToolCommand(id));
        return NoContent();
    }

    [HttpGet("get-for-service-by-id/{serviceId:int}")]
    public async Task<IActionResult> GetToolsByServiceId(int serviceId)
    {
        var tools = await _mediator.Send(new GetToolsForServiceQuery{ ServiceId = serviceId });
        if(tools == null || tools.Count() == 0)
            return NotFound();
        
        return Ok(new { data = tools });
    }

    [HttpGet("get-by-serial-number/{serialNumber:int}")]
    public async Task<IActionResult> GetToolBySerialNumber(int serialNumber)
    {
        var tool = await _mediator.Send(new GetToolBySerialNumberQuery { SerialNumber = serialNumber });
        if(tool == null)
            return NotFound();
        
        return Ok(new { data = tool });
    }
}