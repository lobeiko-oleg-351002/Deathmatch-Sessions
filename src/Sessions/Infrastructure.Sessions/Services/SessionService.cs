using AutoMapper;
using Domain.Interfaces;
using Infrastructure.Common.Service;
using Application.Sessions.DTO;
using Application.Sessions.Interfaces;
using Domain.Entities;
using Infrastructure.Common.Exceptions;
using Infrastructure.Sessions.Exceptions;

namespace Infrastructure.Sessions.Services;

public class SessionService : Service<Session, ViewSessionDTO, CreateSessionDTO>, ISessionService
{
    private readonly IUserInSessionRepository _userInSessionRepository;
    private readonly ILocationRepository _locationRepository;
    public SessionService(ISessionRepository sessionRepository, IUserInSessionRepository userInSessionRepository, ILocationRepository locationRepository, IMapper mapper)
        : base(sessionRepository, mapper)
    {
        _userInSessionRepository = userInSessionRepository;
        _locationRepository = locationRepository;
    }

    public override async Task<ViewSessionDTO> Create(CreateSessionDTO dto)
    {
        var location = await _locationRepository.Get(Guid.Parse(dto.LevelId));
        var entity = new Session { Level = location, Name = dto.Name, UserHostId = Guid.Parse(dto.UserHostId) };
        return _mapper.Map<ViewSessionDTO>(await _repository.Create(entity));
    }

    public async Task<ViewUserInSessionDTO> AddUserToSession(AddUserToSessionDTO dto)
    {
        try
        {
            var session = await _repository.Get(Guid.Parse(dto.SessionId));
            var userInSession = await _userInSessionRepository.Create(new UserInSession { UserId = Guid.Parse(dto.UserId), Session = session, DeathCount = 0, KillCount = 0 });
            return _mapper.Map<ViewUserInSessionDTO>(userInSession);
        }
        catch (ItemNotFoundException)
        {
            throw new SessionNotFoundException();
        }
    }

    public async Task<List<ViewUserInSessionDTO>> GetUsersInSession(GetUsersInSessionDTO dto)
    {
        try
        {
            var session = await _repository.Get(Guid.Parse(dto.SessionId));
            var entities = await _userInSessionRepository.GetUsersInParticularSession(session);
            return entities.Select(_mapper.Map<ViewUserInSessionDTO>).ToList();
                   
        }
        catch(ItemNotFoundException)
        {
            throw new SessionNotFoundException();
        }
        catch(NoElementsException)
        {
            throw new NoUsersException();
        }
    }
}