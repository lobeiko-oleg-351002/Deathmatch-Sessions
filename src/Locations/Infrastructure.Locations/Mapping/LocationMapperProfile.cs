﻿using Application.Locations.Commands;
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
        CreateMap<CreateLocationDTO, Location>().ForMember(x => x.Id, opt => opt.Ignore());
        CreateMap<CreateLocationCommand, CreateLocationDTO>();
    }
}
