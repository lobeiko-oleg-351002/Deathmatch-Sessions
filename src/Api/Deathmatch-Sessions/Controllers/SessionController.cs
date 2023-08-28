using Application.Locations.Queries;
using Application.Sessions.Commands;
using Application.Sessions.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
public class SessionController : ControllerBase
{
    private readonly IMediator _mediator;

    public SessionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route("session")]
    public async Task CreateSession([FromForm] CreateSessionCommand cmd)
    {
        await _mediator.Send(cmd);
    }

    [HttpGet]
    [Route("sessions")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllSessionsQuery());
        return Ok(result);
    }

    [HttpPost]
    [Route("sessions/user")]
    public async Task AddUserToSession([FromForm] AddProfileToSessionCommand cmd)
    {
        await _mediator.Send(cmd);
    }

    [HttpGet]
    [Route("sessions/user/{id}")]
    public async Task<IActionResult> GetUsersInSession(Guid id)
    {
        var result = await _mediator.Send(new GetPlayerProfilesInSessionQuery { SessionId = id });
        return Ok(result);
    }

    [HttpGet]
    [Route("session/{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var result = await _mediator.Send(new GetSessionQuery { Id = id });
        return Ok(result);
    }
}
