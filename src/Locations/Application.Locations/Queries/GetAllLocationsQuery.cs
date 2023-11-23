using Application.Locations.DTO;
using Application.Locations.Interfaces;
using MediatR;

namespace Application.Locations.Queries;
public class GetAllLocationsQuery : IRequest<IList<ViewLocationDTO>>
{
}

public class GetAllLocationsQueryHandler : IRequestHandler<GetAllLocationsQuery, IList<ViewLocationDTO>>
{
    private readonly ILocationService _LocationService;

    public GetAllLocationsQueryHandler(ILocationService LocationService)
    {
        _LocationService = LocationService;
    }
    public async Task<IList<ViewLocationDTO>> Handle(GetAllLocationsQuery request, CancellationToken cancellationToken)
    {
        ; return await _LocationService.GetAll();
    }
}
