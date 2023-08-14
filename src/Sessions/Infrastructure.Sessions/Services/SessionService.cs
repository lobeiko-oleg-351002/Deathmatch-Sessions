using AutoMapper;
using Domain.Interfaces;
using Infrastructure.Common.Service;
using Application.Sessions.DTO;
using Application.Sessions.Interfaces;
using Domain.Entities;

namespace Infrastructure.Sessions.Services;

public class SessionService : Service<Session, ViewSessionDTO, CreateSessionDTO>, ISessionService
{
    public SessionService(ISessionRepository SessionRepository, IMapper mapper)
        : base(SessionRepository, mapper)
    {

    }

}
