using Application.Common.Interface;
using Application.Sessions.DTO;

namespace Application.Sessions.Interfaces;

public interface ISessionService : IService<ViewSessionDTO, CreateSessionDTO>
{
    Task<ViewProfileInSessionDTO> AddProfileToSession(AddPlayerProfileToSessionDTO dto);
    Task<List<ViewProfileInSessionDTO>> GetProfilesInSession(GetPlayerProfilesInSessionDTO dto);
}
