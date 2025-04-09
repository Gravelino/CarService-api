using Application.Features.Payments.CreatePayment;
using Application.Features.Payments.GetPaymentById;
using Application.Features.Payments.GetPaymentsByVisitId;
using Application.Features.Payments.GetTotalPaymentsForVisit;
using Application.Features.Payments.RestorePayment;
using Application.Features.Payments.SoftDeletePayment;
using Application.Features.Payments.UpdatePayment;
using Application.Features.Services.GetAllServices;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentsController : Controller
{
    private readonly IMediator _mediator;
    
    public PaymentsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllPayments(
        [FromQuery] int page = 1,
        [FromQuery] int perPage = 10,
        [FromQuery] string sort = "Id",
        [FromQuery] string order = "ASC",
        [FromQuery] string? nameLike = null)
    {
        var query = new GetAllServiceCategoriesQuery
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
    public async Task<IActionResult> GetPaymentById(int id)
    {
        var payment = await _mediator.Send(new GetPaymentByIdQuery{Id = id});
        if (payment == null)
            return NotFound();
        
        return Ok(new { data = payment });
    }

    [HttpPost]
    public async Task<IActionResult> CreatePayment([FromBody] CreatePaymentCommand command)
    {
        var paymentId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetPaymentById), new {id = paymentId}, paymentId);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdatePayment(int id, 
        [FromBody] UpdatePaymentCommand command)
    {
        if(id != command.Id)
            return BadRequest();
        
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpPut("{id:int}/softDelete")]
    public async Task<IActionResult> DeletePayment(int id)
    {
        await _mediator.Send(new SoftDeletePaymentCommand(id));
        return NoContent();
    }

    [HttpPut("{id:int}/restore")]
    public async Task<IActionResult> RestorePayment(int id)
    {
        await _mediator.Send(new RestorePaymentCommand(id));
        return NoContent();
    }

    [HttpGet("get-payments-by-visitId/{visitId:int}")]
    public async Task<IActionResult> GetPaymentsByVisitId(int visitId)
    {
        var payments = await _mediator.Send(new GetPaymentsByVisitIdQuery{VisitId = visitId});
        if(payments == null)
            return NotFound();
        
        return Ok(new {data = payments});
    }

    [HttpGet("get-total-payments-by-visitId/{visitId:int}")]
    public async Task<IActionResult> GetTotalPaymentsByVisitId(int visitId)
    {
        var payments = await _mediator.Send(new GetTotalPaymentsForVisitQuery{VisitId = visitId});
        return Ok(new {data = payments});
    }
}