using Application.PlayerProfiles.DTO;

namespace Application.Sessions.Interfaces;

public interface IUserExternalService
{
    Task<ViewPlayerProfileDTO> GetUser(Guid id);
}
