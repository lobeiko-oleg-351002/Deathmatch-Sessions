using Application.Sessions.DTO;

namespace Application.Sessions.Interfaces
{
    public interface IUserExternalService
    {
        Task<ViewUserDTO> GetUser(Guid id);
    }
}
