using Application.Sessions.DTO;
using Application.Sessions.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Sessions.Commands;

public record AddProfileToSessionCommand : IRequest<Unit>
{
    public required Guid ProfileId { get; set; }

    public required Guid SessionId { get; set; }
}

public class AddProfileToSessionCommandHandler : IRequestHandler<AddProfileToSessionCommand, Unit>
{
    private readonly ISessionService _SessionService;
    private readonly IMapper _mapper;
    public AddProfileToSessionCommandHandler(ISessionService SessionService, IMapper mapper)
    {
        _SessionService = SessionService;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(AddProfileToSessionCommand request, CancellationToken cancellationToken)
    {
        await _SessionService.AddProfileToSession(_mapper.Map<AddPlayerProfileToSessionDTO>(request));
        return Unit.Value;
    }
}
