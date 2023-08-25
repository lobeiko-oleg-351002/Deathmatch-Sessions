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
        CreateMap<UserInSession, ViewUserInSessionDTO>().ForMember(entity => entity.Name, opt => opt.Ignore());
        CreateMap<AddUserToSessionCommand, AddUserToSessionDTO>();
        CreateMap<GetUsersInSessionQuery, GetUsersInSessionDTO>();
    }
}
