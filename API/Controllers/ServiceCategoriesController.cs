using Application.Features.ServiceCategories.GetServiceCategoryById;
using Application.Features.ServiceCategories.RestoreServiceCategory;
using Application.Features.ServiceCategories.SoftDeleteServiceCategory;
using Application.Features.ServiceCategories.UpdateServiceCategory;
using Application.Features.Services.CreateService;
using Application.Features.Services.GetAllServices;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ServiceCategoriesController : Controller
{
    private readonly IMediator _mediator;
    
    public ServiceCategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllServiceCategories(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] string sort = "Id",
        [FromQuery] string order = "ASC",
        [FromQuery] string? nameLike = null,
        [FromQuery] string? descriptionLike = null)
    {
        try
        {
            var query = new GetAllServiceCategoriesQuery
            {
                Page = page,
                PageSize = pageSize,
                SortField = sort,
                SortOrder = order,
                NameFilter = nameLike,
                DescriptionFilter = descriptionLike
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
    public async Task<IActionResult> GetServiceCategoryById(int id)
    {
        var serviceCategory = await _mediator.Send(new GetServiceCategoryByIdQuery(id));
        if (serviceCategory == null)
            return NotFound();
        
        return Ok(new { data = serviceCategory });
    }

    [HttpPost]
    public async Task<IActionResult> CreateServiceCategory([FromBody] CreateServiceCategoryCommand command)
    {
        var serviceCategoryId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetServiceCategoryById), new {id = serviceCategoryId}, serviceCategoryId);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateServiceCategory(int id, 
        [FromBody] UpdateServiceCategoryCommand command)
    {
        if(id != command.Id)
            return BadRequest();
        
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpPut("{id:int}/softDelete")]
    public async Task<IActionResult> DeleteServiceCategory(int id)
    {
        await _mediator.Send(new SoftDeleteServiceCategoryCommand(id));
        return NoContent();
    }

    [HttpPut("{id:int}/restore")]
    public async Task<IActionResult> RestoreServiceCategory(int id)
    {
        await _mediator.Send(new RestoreServiceCategoryCommand(id));
        return NoContent();
    }
}