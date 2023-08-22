using Application.Sessions.DTO;
using Application.Sessions.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Sessions.Queries;

public class GetUsersInSessionQuery : IRequest<IList<ViewUserInSessionDTO>>
{
    public required Guid SessionId { get; set; }
}

public class GetUsersInSessionQueryHandler : IRequestHandler<GetUsersInSessionQuery, IList<ViewUserInSessionDTO>>
{
    private readonly ISessionService _sessionService;
    private readonly IMapper _mapper;

    public GetUsersInSessionQueryHandler(ISessionService sessionService, IMapper mapper)
    {
        _sessionService = sessionService;
        _mapper = mapper;
    }
    public async Task<IList<ViewUserInSessionDTO>> Handle(GetUsersInSessionQuery request, CancellationToken cancellationToken)
    {
        return await _sessionService.GetUsersInSession(_mapper.Map<GetUsersInSessionDTO>(request));
    }
}
