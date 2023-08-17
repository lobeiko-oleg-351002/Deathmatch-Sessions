using Application.Sessions.Commands;
using Application.Sessions.DTO;
using Application.Sessions.Queries;
using AutoMapper;
using Domain.Entities;

namespace Infrastructure.Sessions.Mapping;

public class UserInSessionMapperProfile : Profile
{
    public UserInSessionMapperProfile()
    {
        CreateMap<UserInSession, ViewUserInSessionDTO>()
            .ForMember(dto => dto.Id, entity => entity.MapFrom(x => x.Id.ToString()));
        CreateMap<AddUserToSessionCommand, AddUserToSessionDTO>();
        CreateMap<GetUsersInSessionQuery, GetUsersInSessionDTO>();
    }
}
