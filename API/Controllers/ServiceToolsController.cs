using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ServiceToolsController : ControllerBase
{
    private readonly IServiceToolRepository _serviceToolRepository;

    public ServiceToolsController(IServiceToolRepository serviceToolRepository)
    {
        _serviceToolRepository = serviceToolRepository;
    }

    [HttpGet("service/{serviceId}")]
    public async Task<ActionResult<IEnumerable<int>>> GetToolsForService(int serviceId)
    {
        var toolIds = await _serviceToolRepository.GetToolIdsByServiceIdAsync(serviceId);
        return Ok(toolIds);
    }

    [HttpPost("update/{serviceId}")]
    public async Task<IActionResult> UpdateServiceTools(int serviceId, [FromBody] List<int> toolIds)
    {
        await _serviceToolRepository.DeleteByServiceIdAsync(serviceId);

        foreach (var toolId in toolIds)
        {
            var serviceTool = new ServiceTool
            {
                ServicesId = serviceId,
                ToolsId = toolId
            };
            await _serviceToolRepository.AddAsync(serviceTool);
        }

        await _serviceToolRepository.SaveChangesAsync();
        return Ok();
    }

    [HttpPost("create/{serviceId}")]
    public async Task<IActionResult> CreateServiceTools(int serviceId, [FromBody] List<int> toolIds)
    {
        foreach (var toolId in toolIds)
        {
            var serviceTool = new ServiceTool
            {
                ServicesId = serviceId,
                ToolsId = toolId
            };
            await _serviceToolRepository.AddAsync(serviceTool);
        }

        await _serviceToolRepository.SaveChangesAsync();
        return Ok();
    }
}