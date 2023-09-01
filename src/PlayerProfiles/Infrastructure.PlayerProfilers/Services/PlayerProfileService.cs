using AutoMapper;
using Infrastructure.Common.Service;
using Domain.Entities;
using Application.PlayerProfiles.DTO;
using Domain.Interfaces;
using Application.PlayerProfiles.Interfaces;

namespace Infrastructure.PlayerProfiles.Services;

public class PlayerProfileService : Service<PlayerProfile, ViewPlayerProfileDTO, CreatePlayerProfileDTO>, IPlayerProfileService
{
    public PlayerProfileService(IPlayerProfileRepository PlayerProfileRepository, IMapper mapper)
        : base(PlayerProfileRepository, mapper)
    {

    }
}
