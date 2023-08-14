using Application.Sessions.Commands;
using Application.Sessions.DTO;
using AutoMapper;
using Domain.Entities;

namespace Infrastructure.Locations.Mapping;

public class UserInSessionMapperProfile : Profile
{
    public UserInSessionMapperProfile()
    {
        CreateMap<UserInSession, ViewUserInSessionDTO>()
            .ForMember(dto => dto.Id, entity => entity.MapFrom(x => x.Id.ToString()));
        CreateMap<AddUserToSessionCommand, AddUserToSessionDTO>().ForMember(x => x.Id, opt => opt.Ignore());
    }
}
