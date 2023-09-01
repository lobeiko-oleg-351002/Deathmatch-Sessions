using Application.PlayerProfiles.DTO;
using Application.PlayerProfiles.Interfaces;
using MediatR;

namespace Application.PlayerProfiles.Queries;
public class GetAllPlayerProfilesQuery : IRequest<IList<ViewPlayerProfileDTO>>
{
}

public class GetAllPlayerProfilesQueryHandler : IRequestHandler<GetAllPlayerProfilesQuery, IList<ViewPlayerProfileDTO>>
{
    private readonly IPlayerProfileService _PlayerProfileService;

    public GetAllPlayerProfilesQueryHandler(IPlayerProfileService PlayerProfileService)
    {
        _PlayerProfileService = PlayerProfileService;
    }
    public async Task<IList<ViewPlayerProfileDTO>> Handle(GetAllPlayerProfilesQuery request, CancellationToken cancellationToken)
    {
        return await _PlayerProfileService.GetAll();
    }
}
