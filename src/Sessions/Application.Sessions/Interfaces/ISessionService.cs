using Application.Common.Interface;
using Application.Sessions.DTO;

namespace Application.Sessions.Interfaces;

public interface ISessionService : IService<ViewSessionDTO, CreateSessionDTO>
{

}
