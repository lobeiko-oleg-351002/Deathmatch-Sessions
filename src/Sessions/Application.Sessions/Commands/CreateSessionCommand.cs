using Application.Locations.DTO;
using Application.Sessions.DTO;
using Application.Sessions.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Sessions.Commands;
public record CreateSessionCommand : IRequest<Unit>
{
    public required string Name { get; set; }

    public required int MaxPlayerCount { get; set; }

    public required Guid LevelId { get; set; }

    public required Guid UserHostId { get; set; }
}

public class CreateSessionCommandHandler : IRequestHandler<CreateSessionCommand, Unit>
{
    private readonly ISessionService _SessionService;
    private readonly IMapper _mapper;
    public CreateSessionCommandHandler(ISessionService SessionService, IMapper mapper)
    {
        _SessionService = SessionService;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(CreateSessionCommand request, CancellationToken cancellationToken)
    {
        await _SessionService.Create(_mapper.Map<CreateSessionDTO>(request));
        return Unit.Value;
    }
}


