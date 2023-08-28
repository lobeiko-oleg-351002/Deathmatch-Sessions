using Application.Profiles.DTO;

namespace Application.Sessions.Interfaces;

public interface IUserExternalService
{
    Task<ViewPlayerProfileDTO> GetUser(Guid id);
}
