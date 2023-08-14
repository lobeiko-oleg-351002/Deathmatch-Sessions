using Application.Locations.Queries;
using Application.Sessions.Commands;
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


    //  [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllSessionsQuery());
        return Ok(result);
    }
}
