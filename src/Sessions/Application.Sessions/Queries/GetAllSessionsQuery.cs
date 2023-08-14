using Application.Locations.DTO;
using Application.Locations.Interfaces;
using Application.Sessions.DTO;
using Application.Sessions.Interfaces;
using MediatR;

namespace Application.Locations.Queries;
public class GetAllSessionsQuery : IRequest<IList<ViewSessionDTO>>
{
}

public class GetAllSessionsQueryHandler : IRequestHandler<GetAllSessionsQuery, IList<ViewSessionDTO>>
{
    private readonly ISessionService _sessionService;

    public GetAllSessionsQueryHandler(ISessionService sessionService)
    {
        _sessionService = sessionService;
    }
    public async Task<IList<ViewSessionDTO>> Handle(GetAllSessionsQuery request, CancellationToken cancellationToken)
    {
        return await _sessionService.GetAll();
    }
}
