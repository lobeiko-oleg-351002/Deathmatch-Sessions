using Application.Sessions.Commands;
using Application.Sessions.DTO;
using AutoMapper;
using Domain.Entities;

namespace Infrastructure.Locations.Mapping;

public class SessionMapperProfile : Profile
{
    public SessionMapperProfile()
    {
        CreateMap<Session, ViewSessionDTO>()
            .ForMember(dto => dto.Id, entity => entity.MapFrom(x => x.Id.ToString()));
        CreateMap<CreateSessionDTO, Session>()
            .ForMember(entity => entity.Id, dto => dto.MapFrom(x => Guid.Parse(x.Id)));
        CreateMap<CreateSessionCommand, CreateSessionDTO>().ForMember(x => x.Id, opt => opt.Ignore());
    }
}
