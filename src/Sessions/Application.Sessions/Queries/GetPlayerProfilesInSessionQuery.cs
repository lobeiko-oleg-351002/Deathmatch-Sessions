using Application.Sessions.DTO;
using Application.Sessions.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Sessions.Queries;

public class GetPlayerProfilesInSessionQuery : IRequest<IList<ViewProfileInSessionDTO>>
{
    public required Guid SessionId { get; set; }
}

public class GetPlayerProfilesInSessionQueryHandler : IRequestHandler<GetPlayerProfilesInSessionQuery, IList<ViewProfileInSessionDTO>>
{
    private readonly ISessionService _sessionService;
    private readonly IMapper _mapper;

    public GetPlayerProfilesInSessionQueryHandler(ISessionService sessionService, IMapper mapper)
    {
        _sessionService = sessionService;
        _mapper = mapper;
    }
    public async Task<IList<ViewProfileInSessionDTO>> Handle(GetPlayerProfilesInSessionQuery request, CancellationToken cancellationToken)
    {
        return await _sessionService.GetProfilesInSession(_mapper.Map<GetPlayerProfilesInSessionDTO>(request));
    }
}
