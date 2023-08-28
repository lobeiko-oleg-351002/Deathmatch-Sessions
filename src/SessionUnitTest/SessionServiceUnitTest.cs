using Application.Sessions.DTO;
using Application.Sessions.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Common.Exceptions;
using Infrastructure.Sessions.Exceptions;
using Infrastructure.Sessions.Services;
using Moq;

namespace SessionUnitTests;
public class SessionServiceUnitTest
{
    private readonly IMapper _mapper;
    public SessionServiceUnitTest()
    {
        _mapper = MappingConfigForTests.CreateMapper();
    }

    [Fact]
    public async void SessionService_Create_Success()
    {
        var createDTO = new CreateSessionDTO { MaxPlayerCount = 4, Name = "oleg", UserHostId = new Guid("13d54b8e-2c1f-4e35-49fb-08db94cbee6d"), LevelId = new Guid("13d54b8e-2c1f-4e35-49fb-08db94cbee6d") };
        var expected = new ViewSessionDTO() { Id = new Guid(), Name = createDTO.Name };

        var mockLocation = new Location { Id = createDTO.LevelId, Name = "Facing Worlds", LevelFilepath = "levels/face.utm", PosterFilepath = "posters/face.png" };
        var entity = new Session { Id = expected.Id, Level = mockLocation, Name = createDTO.Name, UserHostId = createDTO.UserHostId, MaxPlayerCount = createDTO.MaxPlayerCount };


        var mockSessionRepository = new Mock<ISessionRepository>();
        mockSessionRepository.Setup(repository => repository.Create(It.Is<Session>(Session => Session.Name == entity.Name)).Result).Returns(entity);

        var mockLocationRepository = new Mock<ILocationRepository>();
        
        mockLocationRepository.Setup(repository => repository.Get(It.IsAny<Guid>()).Result).Returns(mockLocation);

        var mockUserInSessionRepository = new Mock<IPlayerProfileInSessionRepository>();

        var mockExternalUserService = new Mock<IUserExternalService>();

        var mockPlayerProfileRepository = new Mock<IPlayerProfileRepository>();

        ISessionService service = new SessionService(mockSessionRepository.Object, mockUserInSessionRepository.Object, mockLocationRepository.Object, mockPlayerProfileRepository.Object, mockExternalUserService.Object, _mapper);
        var actual = await service.Create(createDTO);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async void SessionService_Create_FailedWhenRepositoryReturnsNull()
    {
        var createDTO = new CreateSessionDTO { MaxPlayerCount = 4, Name = "oleg", UserHostId = new Guid("13d54b8e-2c1f-4e35-49fb-08db94cbee6d"), LevelId = new Guid("13d54b8e-2c1f-4e35-49fb-08db94cbee6d") };

        var mockSessionRepository = new Mock<ISessionRepository>();
        mockSessionRepository.Setup(repository => repository.Create(It.IsAny<Session>()).Result).Throws(new DalCreateException("mock exception"));

        var mockLocationRepository = new Mock<ILocationRepository>();

        var mockUserInSessionRepository = new Mock<IPlayerProfileInSessionRepository>();

        var mockExternalUserService = new Mock<IUserExternalService>();

        var mockPlayerProfileRepository = new Mock<IPlayerProfileRepository>();

        ISessionService service = new SessionService(mockSessionRepository.Object, mockUserInSessionRepository.Object, mockLocationRepository.Object, mockPlayerProfileRepository.Object, mockExternalUserService.Object, _mapper);
        await Assert.ThrowsAsync<DalCreateException>(async () => await service.Create(createDTO));
    }

    [Fact]
    public async void SessionService_AddPlayerProfileToSession_Success()
    {
        var createDTO = new AddPlayerProfileToSessionDTO { ProfileId = new Guid("13d54b8e-2c1f-4e35-49fb-08db94cbee6d") , SessionId = new Guid("24d54b8e-2c1f-4e35-49fb-08db94cbee6d") };

        var mockLocation = new Location { Id = new Guid(), Name = "Facing Worlds", LevelFilepath = "levels/face.utm", PosterFilepath = "posters/face.png" };

        var mockSessionRepository = new Mock<ISessionRepository>();
        var mockSession = new Session { Id = createDTO.SessionId, Name = "mockSession", MaxPlayerCount = 16, UserHostId = createDTO.ProfileId, Level = mockLocation };
        mockSessionRepository.Setup(repository => repository.Get(It.IsAny<Guid>()).Result).Returns(mockSession);

        var mockLocationRepository = new Mock<ILocationRepository>();

        var expected = new ViewProfileInSessionDTO() { DeathCount = 0, KillCount = 0, Id = new Guid() };

        var mockProfile = new PlayerProfile { Name = "profile", UserId = new Guid("13d54b8e-2c1f-4e35-49fb-08db94cbee6d"), Id = new Guid() };

        var mockPlayerProfileInSessionRepository = new Mock<IPlayerProfileInSessionRepository>();
        var mockPlayerProfileInSession = new PlayerProfileInSession { Session = mockSession, DeathCount = 0, KillCount = 0, PlayerProfile = mockProfile };
        mockPlayerProfileInSessionRepository.Setup(repository => repository.Create(It.IsAny<PlayerProfileInSession>()).Result).Returns(mockPlayerProfileInSession);

        var mockExternalUserService = new Mock<IUserExternalService>();

        var mockPlayerProfileRepository = new Mock<IPlayerProfileRepository>();

        ISessionService service = new SessionService(mockSessionRepository.Object, mockPlayerProfileInSessionRepository.Object, mockLocationRepository.Object, mockPlayerProfileRepository.Object, mockExternalUserService.Object, _mapper);
        var actual = await service.AddProfileToSession(createDTO);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async void SessionService_AddUserToSession_FailedOnNonexistingSession()
    {
        var createDTO = new AddPlayerProfileToSessionDTO { ProfileId = new Guid("13d54b8e-2c1f-4e35-49fb-08db94cbee6d"), SessionId = new Guid("24d54b8e-2c1f-4e35-49fb-08db94cbee6d") };

        var mockSessionRepository = new Mock<ISessionRepository>();
        Session mockSession = null;
        mockSessionRepository.Setup(repository => repository.Get(It.IsAny<Guid>())).Throws(new ItemNotFoundException());

        var mockLocationRepository = new Mock<ILocationRepository>();

        var mockUserInSessionRepository = new Mock<IPlayerProfileInSessionRepository>();

        var mockExternalUserService = new Mock<IUserExternalService>();

        var mockPlayerProfileRepository = new Mock<IPlayerProfileRepository>();

        ISessionService service = new SessionService(mockSessionRepository.Object, mockUserInSessionRepository.Object, mockLocationRepository.Object, mockPlayerProfileRepository.Object, mockExternalUserService.Object, _mapper);
        await Assert.ThrowsAsync<SessionNotFoundException>(async () => await service.AddProfileToSession(createDTO));
    }

    [Fact]
    public async void SessionService_GetPlayerProfilesInSession_Success()
    {
        var getDTO = new GetPlayerProfilesInSessionDTO { SessionId = new Guid("24d54b8e-2c1f-4e35-49fb-08db94cbee6d") };

        var mockSessionRepository = new Mock<ISessionRepository>();
        var mockLocation = new Location { Id = new Guid(), Name = "Facing Worlds", LevelFilepath = "levels/face.utm", PosterFilepath = "posters/face.png" };
        var mockSession = new Session { Id = new Guid(), Name = "mockSession", MaxPlayerCount = 16, UserHostId = new Guid(), Level = mockLocation };
        mockSessionRepository.Setup(repository => repository.Get(It.IsAny<Guid>()).Result).Returns(mockSession);

        var mockLocationRepository = new Mock<ILocationRepository>();

        var mockUserInSessionRepository = new Mock<IPlayerProfileInSessionRepository>();
        var mockProfile = new PlayerProfile { Name = "profile", UserId = new Guid("13d54b8e-2c1f-4e35-49fb-08db94cbee6d"), Id = new Guid() };
        var mockUserInSession = new PlayerProfileInSession { DeathCount = 1, KillCount = 0, Session = mockSession, Id = new Guid(), PlayerProfile = mockProfile };
        mockUserInSessionRepository.Setup(repository => repository.GetProfilesInParticularSession(mockSession).Result).Returns(new List<PlayerProfileInSession> { mockUserInSession });

        var mockExternalUserService = new Mock<IUserExternalService>();

        var mockPlayerProfileRepository = new Mock<IPlayerProfileRepository>();

        ISessionService service = new SessionService(mockSessionRepository.Object, mockUserInSessionRepository.Object, mockLocationRepository.Object, mockPlayerProfileRepository.Object, mockExternalUserService.Object, _mapper);
        var actual = await service.GetProfilesInSession(getDTO);
        mockSessionRepository.Verify(mock => mock.Get(getDTO.SessionId));
        mockUserInSessionRepository.Verify(mock => mock.GetProfilesInParticularSession(mockSession));
    }
}
