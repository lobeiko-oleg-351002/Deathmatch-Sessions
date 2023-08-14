using AutoMapper;
using Domain.Interfaces;
using Infrastructure.Common.Service;
using Application.Locations.DTO;
using Application.Locations.Interfaces;
using Domain.Entities;

namespace Infrastructure.Locations.Services;

public class LocationService : Service<Location, ViewLocationDTO, CreateLocationDTO>, ILocationService
{
    public LocationService(ILocationRepository LocationRepository, IMapper mapper)
        : base(LocationRepository, mapper)
    {

    }

}
