using Application.Locations.DTO;
using Application.Locations.Interfaces;
using MediatR;

namespace Application.Locations.Queries;
public class GetAllSessionsQuery : IRequest<IList<ViewLocationDTO>>
{
}

public class GetAllLocationsQueryHandler : IRequestHandler<GetAllSessionsQuery, IList<ViewLocationDTO>>
{
    private readonly ILocationService _LocationService;

    public GetAllLocationsQueryHandler(ILocationService LocationService)
    {
        _LocationService = LocationService;
    }
    public async Task<IList<ViewLocationDTO>> Handle(GetAllSessionsQuery request, CancellationToken cancellationToken)
    {
        return await _LocationService.GetAll();
    }
}
