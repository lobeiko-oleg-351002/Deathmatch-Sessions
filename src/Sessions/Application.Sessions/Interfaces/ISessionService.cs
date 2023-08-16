using Application.Common.Interface;
using Application.Sessions.DTO;

namespace Application.Sessions.Interfaces;

public interface ISessionService : IService<ViewSessionDTO, CreateSessionDTO>
{
    Task<ViewUserInSessionDTO> AddUserToSession(AddUserToSessionDTO dto);
    Task<List<ViewUserInSessionDTO>> GetUsersInSession(GetUsersInSessionDTO dto);
}
