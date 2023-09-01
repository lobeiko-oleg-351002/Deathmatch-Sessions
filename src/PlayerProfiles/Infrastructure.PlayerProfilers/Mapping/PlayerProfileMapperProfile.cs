using Application.PlayerProfiles.Commands;
using Application.PlayerProfiles.DTO;
using AutoMapper;
using Domain.Entities;

namespace Infrastructure.PlayerProfiles.Mapping;

public class PlayerProfileMapperProfile : Profile
{
    public PlayerProfileMapperProfile()
    {
        CreateMap<PlayerProfile, ViewPlayerProfileDTO>()
            .ForMember(dto => dto.Id, entity => entity.MapFrom(x => x.Id.ToString()));
        CreateMap<CreatePlayerProfileDTO, PlayerProfile>().ForMember(x => x.Id, opt => opt.Ignore());
        CreateMap<CreatePlayerProfileCommand, CreatePlayerProfileDTO>();
    }
}
