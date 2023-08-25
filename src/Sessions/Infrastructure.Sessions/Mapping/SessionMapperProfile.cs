using Application.Sessions.Commands;
using Application.Sessions.DTO;
using AutoMapper;
using Domain.Entities;

namespace Infrastructure.Sessions.Mapping;

public class SessionMapperProfile : Profile
{
    public SessionMapperProfile()
    {
        CreateMap<Session, ViewSessionDTO>().ForMember(entity => entity.HostName, opt => opt.Ignore());
        CreateMap<CreateSessionCommand, CreateSessionDTO>();
    }
}
