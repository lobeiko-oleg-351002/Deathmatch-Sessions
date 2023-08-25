using Application.Locations.Queries;
using Application.Sessions.Commands;
using Application.Sessions.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class SessionController : ControllerBase
{
    private readonly IMediator _mediator;

    public SessionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task CreateSession([FromForm] CreateSessionCommand cmd)
    {
        await _mediator.Send(cmd);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllSessionsQuery());
        return Ok(result);
    }

    [HttpPost]
    public async Task AddUserToSession([FromForm] AddUserToSessionCommand cmd)
    {
        await _mediator.Send(cmd);
    }

    [HttpGet]
    public async Task<IActionResult> GetUsersInSession([FromQuery] GetUsersInSessionQuery cmd)
    {
        var result = await _mediator.Send(cmd);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetSessionQuery cmd)
    {
        var result = await _mediator.Send(cmd);
        return Ok(result);
    }
}
