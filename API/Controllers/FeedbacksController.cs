using Application.Features.Feedbacks.CreateFeedback;
using Application.Features.Feedbacks.GetAllFeedbacks;
using Application.Features.Feedbacks.GetFeedbackById;
using Application.Features.Feedbacks.RestoreFeedback;
using Application.Features.Feedbacks.SoftDeleteFeedback;
using Application.Features.Feedbacks.UpdateFeedback;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FeedbacksController : Controller
{
    private readonly IMediator _mediator;
    
    public FeedbacksController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllFeedbacks(
        [FromQuery] int page = 1,
        [FromQuery] int perPage = 10,
        [FromQuery] string sort = "Id",
        [FromQuery] string order = "ASC",
        [FromQuery] string? nameLike = null)
    {
        var query = new GetAllFeedbacksQuery
        {
            Page = page,
            PageSize = perPage,
            SortField = sort,
            SortOrder = order,
            NameFilter = nameLike,
        };
        
        var result = await _mediator.Send(query);
        
        //Response.Headers.Add("Content-Range", $"Feedbacks {0}-{0 + Feedbacks.Count() - 1}/{Feedbacks.Count()}");
        //Response.Headers.Add("Access-Control-Expose-Headers", "Content-Range");
        
        return Ok(new { data = result.Items, total = result.TotalCount});
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetFeedbackById(int id)
    {
        var feedback = await _mediator.Send(new GetFeedbackByIdQuery{ FeedbackId = id });
        if (feedback == null)
            return NotFound();
        
        return Ok(new { data = feedback });
    }

    [HttpPost]
    public async Task<IActionResult> CreateFeedback([FromBody] CreateFeedbackCommand command)
    {
        var feedbackId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetFeedbackById), new {id = feedbackId}, feedbackId);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateFeedback(int id, 
        [FromBody] UpdateFeedbackCommand command)
    {
        if(id != command.Id)
            return BadRequest();
        
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpPut("{id:int}/softDelete")]
    public async Task<IActionResult> DeleteFeedback(int id)
    {
        await _mediator.Send(new SoftDeleteFeedbackCommand(id));
        return NoContent();
    }

    [HttpPut("{id:int}/restore")]
    public async Task<IActionResult> RestoreFeedback(int id)
    {
        await _mediator.Send(new RestoreFeedbackCommand(id));
        return NoContent();
    }
}