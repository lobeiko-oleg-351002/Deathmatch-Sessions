using Application.Sessions.DTO;
using Application.Sessions.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Sessions.Commands;

public record AddUserToSessionCommand : IRequest<Unit>
{
    public required string UserId { get; set; }

    public required string SessionId { get; set; }
}

public class AddUserToSessionCommandHandler : IRequestHandler<AddUserToSessionCommand, Unit>
{
    private readonly ISessionService _SessionService;
    private readonly IMapper _mapper;
    public AddUserToSessionCommandHandler(ISessionService SessionService, IMapper mapper)
    {
        _SessionService = SessionService;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(AddUserToSessionCommand request, CancellationToken cancellationToken)
    {
        await _SessionService.AddUserToSession(_mapper.Map<AddUserToSessionDTO>(request));
        return Unit.Value;
    }
}
