using Application.Locations.DTO;
using AutoMapper;
using Domain.Entities;

namespace Infrastructure.Locations.Mapping;

public class LocationMapperProfile : Profile
{
    public LocationMapperProfile()
    {
        CreateMap<Location, ViewLocationDTO>()
            .ForMember(dto => dto.Id, entity => entity.MapFrom(x => x.Id.ToString()));
    }
}
