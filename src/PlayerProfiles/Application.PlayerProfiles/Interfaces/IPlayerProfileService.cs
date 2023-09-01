using Application.Common.Interface;
using Application.PlayerProfiles.DTO;

namespace Application.PlayerProfiles.Interfaces;

public interface IPlayerProfileService : IService<ViewPlayerProfileDTO, CreatePlayerProfileDTO>
{
   
}
