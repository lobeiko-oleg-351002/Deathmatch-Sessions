using Application.Sessions.Commands;
using Application.Sessions.DTO;
using Application.Sessions.Queries;
using AutoMapper;
using Domain.Entities;

namespace Infrastructure.Sessions.Mapping;

public class ProfileInSessionMapperProfile : Profile
{
    public ProfileInSessionMapperProfile()
    {
        CreateMap<PlayerProfileInSession, ViewProfileInSessionDTO>().ForMember(entity => entity.Name, opt => opt.Ignore());
        CreateMap<AddProfileToSessionCommand, AddPlayerProfileToSessionDTO>();
        CreateMap<GetPlayerProfilesInSessionQuery, GetPlayerProfilesInSessionDTO>();
    }
}
