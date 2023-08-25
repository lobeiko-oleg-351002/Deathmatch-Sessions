using Application.Sessions.DTO;
using Application.Sessions.Interfaces;
using MediatR;

namespace Application.Sessions.Queries;
public class GetSessionQuery : IRequest<ViewSessionDTO>
{
    public required Guid Id { get; set; }
}

public class GetSessionQueryHandler : IRequestHandler<GetSessionQuery, ViewSessionDTO>
{
    private readonly ISessionService _sessionService;

    public GetSessionQueryHandler(ISessionService sessionService)
    {
        _sessionService = sessionService;
    }
    public async Task<ViewSessionDTO> Handle(GetSessionQuery request, CancellationToken cancellationToken)
    {
        return await _sessionService.Get(request.Id);
    }
}
