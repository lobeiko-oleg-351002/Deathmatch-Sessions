using Application.Locations.Commands;
using Application.Locations.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
public class LocationController : ControllerBase
{
    private readonly IMediator _mediator;

    public LocationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route("location")]
    public async Task CreateLocation([FromForm] CreateLocationCommand cmd)
    {
        await _mediator.Send(cmd);
    }

    [HttpGet]
    [Route("locations")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllLocationsQuery());
        return Ok(result);
    }
}
