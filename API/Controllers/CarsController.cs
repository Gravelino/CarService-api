using Application.Features.Cars.CreateCar;
using Application.Features.Cars.GetAllCars;
using Application.Features.Cars.GetCarById;
using Application.Features.Cars.GetCarsByCustomerId;
using Application.Features.Cars.GetCarWithVisitHistory;
using Application.Features.Cars.RestoreCar;
using Application.Features.Cars.SoftDeleteCar;
using Application.Features.Cars.UpdateCar;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarsController : Controller
{
   private readonly IMediator _mediator;
    
    public CarsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllCars(
        [FromQuery] int page = 1,
        [FromQuery] int perPage = 10,
        [FromQuery] string sort = "Id",
        [FromQuery] string order = "ASC",
        [FromQuery] string? nameLike = null)
    {
        var query = new GetAllCarsQuery
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
    public async Task<IActionResult> GetCarById(int id)
    {
        var car = await _mediator.Send(new GetCarByIdQuery{ CarId = id });
        if (car == null)
            return NotFound();
        
        return Ok(new { data = car});
    }

    [HttpPost]
    public async Task<IActionResult> CreateCar([FromBody] CreateCarCommand command)
    {
        var carId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetCarById), new {id = carId}, carId);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateCar(int id, 
        [FromBody] UpdateCarCommand command)
    {
        if(id != command.Id)
            return BadRequest();
        
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpPut("{id:int}/softDelete")]
    public async Task<IActionResult> DeleteCar(int id)
    {
        await _mediator.Send(new SoftDeleteCarCommand(id));
        return NoContent();
    }

    [HttpPut("{id:int}/restore")]
    public async Task<IActionResult> RestoreCar(int id)
    {
        await _mediator.Send(new RestoreCarCommand(id));
        return NoContent();
    }

    [HttpGet("get-by-customerId/{customerId:int}")]
    public async Task<IActionResult> GetCarsByCustomerId(int customerId)
    {
        var cars = await _mediator.Send(new GetCarsByCustomerIdQuery{ CustomerId = customerId });
        return Ok(new { data = cars});
    }

    [HttpGet("get-with-visit-history/{id:int}")]
    public async Task<IActionResult> GetCarsWithVisitHistory(int id)
    {
        var car = await _mediator.Send(new GetCarWithVisitHistoryQuery{ CarId = id });
        return Ok(new { data = car});
    }
}