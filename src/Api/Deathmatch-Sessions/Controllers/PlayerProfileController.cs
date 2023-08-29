using Application.PlayerProfiles.Commands;
using Application.PlayerProfiles.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
public class PlayerProfileController : ControllerBase
{
    private readonly IMediator _mediator;

    public PlayerProfileController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route("playerProfile")]
    public async Task CreatePlayerProfile([FromForm] CreatePlayerProfileCommand cmd)
    {
        await _mediator.Send(cmd);
    }

    [HttpGet]
    [Route("playerProfiles")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllPlayerProfilesQuery());
        return Ok(result);
    }
}
