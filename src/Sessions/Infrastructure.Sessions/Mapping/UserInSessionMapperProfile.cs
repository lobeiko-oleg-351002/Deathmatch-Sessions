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
        CreateMap<UserInSession, ViewUserInSessionDTO>();
        CreateMap<AddUserToSessionCommand, AddUserToSessionDTO>();
        CreateMap<GetUsersInSessionQuery, GetUsersInSessionDTO>();
    }
}
