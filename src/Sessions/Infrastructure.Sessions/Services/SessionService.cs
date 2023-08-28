using AutoMapper;
using Domain.Interfaces;
using Infrastructure.Common.Service;
using Application.Sessions.DTO;
using Application.Sessions.Interfaces;
using Domain.Entities;
using Infrastructure.Common.Exceptions;
using Infrastructure.Sessions.Exceptions;
using Application.Sessions.Messages;
using MicroserviceEvents;

namespace Infrastructure.Sessions.Services;

public class SessionService : Service<Session, ViewSessionDTO, CreateSessionDTO>, ISessionService
{
    private readonly IPlayerProfileInSessionRepository _userInSessionRepository;
    private readonly ILocationRepository _locationRepository;
    private readonly IPlayerProfileRepository _playerProfileRepository;
    private readonly IUserExternalService _userExternalService;
    public SessionService(
        ISessionRepository sessionRepository,
        IPlayerProfileInSessionRepository userInSessionRepository,
        ILocationRepository locationRepository,
        IPlayerProfileRepository playerProfileRepository,
        IUserExternalService userExternalService,
        IMapper mapper)
        : base(sessionRepository, mapper)
    {
        _userInSessionRepository = userInSessionRepository;
        _locationRepository = locationRepository;
        _userExternalService = userExternalService;
        _playerProfileRepository = playerProfileRepository;
    }

    public override async Task<ViewSessionDTO> Create(CreateSessionDTO dto)
    {
        var location = await _locationRepository.Get(dto.LevelId);
        var entity = new Session { Level = location, Name = dto.Name, UserHostId = dto.UserHostId };
        return _mapper.Map<ViewSessionDTO>(await _repository.Create(entity));
    }

    public async Task<ViewProfileInSessionDTO> AddProfileToSession(AddPlayerProfileToSessionDTO dto)
    {
        try
        {
            var session = await _repository.Get(dto.SessionId);
            var playerProfile = await _playerProfileRepository.Get(dto.ProfileId);
            var userInSession = await _userInSessionRepository.Create(new PlayerProfileInSession { Id = dto.ProfileId, Session = session, DeathCount = 0, KillCount = 0, PlayerProfile = playerProfile });
            return _mapper.Map<ViewProfileInSessionDTO>(userInSession);
        }
        catch (ItemNotFoundException)
        {
            throw new SessionNotFoundException();
        }
    }

    public async Task<List<ViewProfileInSessionDTO>> GetProfilesInSession(GetPlayerProfilesInSessionDTO dto)
    {
        try
        {
            var session = await _repository.Get(dto.SessionId);
            var entities = await _userInSessionRepository.GetProfilesInParticularSession(session);
            return entities.Select(_mapper.Map<ViewProfileInSessionDTO>).ToList();
                   
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

    public async override Task<ViewSessionDTO> Get(Guid id)
    {
        try
        {
            var session = await _repository.Get(id);
            var userRequest = new UserRequestEvent { User = session.UserHostId };
            var host = await _userExternalService.GetUser(session.UserHostId);
            var result = _mapper.Map<ViewSessionDTO>(session);
            result.HostName = host.Name;
            return result;

        }
        catch (ItemNotFoundException)
        {
            throw new SessionNotFoundException();
        }
        catch (NoElementsException)
        {
            throw new NoUsersException();
        }
    }
}