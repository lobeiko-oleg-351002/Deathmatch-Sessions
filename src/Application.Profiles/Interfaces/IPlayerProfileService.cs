using Application.Common.Interface;
using Application.Profiles.DTO;

namespace Application.Profiles.Interfaces;

public interface IPlayerProfileService : IService<ViewPlayerProfileDTO, CreatePlayerProfileDTO>
{
   
}
