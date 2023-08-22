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

        var mockUserInSessionRepository = new Mock<IUserInSessionRepository>();


        ISessionService service = new SessionService(mockSessionRepository.Object, mockUserInSessionRepository.Object, mockLocationRepository.Object, _mapper);
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

        var mockUserInSessionRepository = new Mock<IUserInSessionRepository>();


        ISessionService service = new SessionService(mockSessionRepository.Object, mockUserInSessionRepository.Object, mockLocationRepository.Object, _mapper);
        await Assert.ThrowsAsync<DalCreateException>(async () => await service.Create(createDTO));
    }

    [Fact]
    public async void SessionService_AddUserToSession_Success()
    {
        var createDTO = new AddUserToSessionDTO { UserId = new Guid("13d54b8e-2c1f-4e35-49fb-08db94cbee6d") , SessionId = new Guid("24d54b8e-2c1f-4e35-49fb-08db94cbee6d") };

        var mockLocation = new Location { Id = new Guid(), Name = "Facing Worlds", LevelFilepath = "levels/face.utm", PosterFilepath = "posters/face.png" };

        var mockSessionRepository = new Mock<ISessionRepository>();
        var mockSession = new Session { Id = createDTO.SessionId, Name = "mockSession", MaxPlayerCount = 16, UserHostId = createDTO.UserId, Level = mockLocation };
        mockSessionRepository.Setup(repository => repository.Get(It.IsAny<Guid>()).Result).Returns(mockSession);

        var mockLocationRepository = new Mock<ILocationRepository>();

        var expected = new ViewUserInSessionDTO() { DeathCount = 0, KillCount = 0, Id = new Guid(), UserId = new Guid("13d54b8e-2c1f-4e35-49fb-08db94cbee6d") };

        var mockUserInSessionRepository = new Mock<IUserInSessionRepository>();
        var mockUserInSession = new UserInSession { UserId = expected.UserId, Session = mockSession, DeathCount = 0, KillCount = 0 };
        mockUserInSessionRepository.Setup(repository => repository.Create(It.IsAny<UserInSession>()).Result).Returns(mockUserInSession);

        ISessionService service = new SessionService(mockSessionRepository.Object, mockUserInSessionRepository.Object, mockLocationRepository.Object, _mapper);
        var actual = await service.AddUserToSession(createDTO);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async void SessionService_AddUserToSession_FailedOnNonexistingSession()
    {
        var createDTO = new AddUserToSessionDTO { UserId = new Guid("13d54b8e-2c1f-4e35-49fb-08db94cbee6d"), SessionId = new Guid("24d54b8e-2c1f-4e35-49fb-08db94cbee6d") };

        var mockSessionRepository = new Mock<ISessionRepository>();
        Session mockSession = null;
        mockSessionRepository.Setup(repository => repository.Get(It.IsAny<Guid>())).Throws(new ItemNotFoundException());

        var mockLocationRepository = new Mock<ILocationRepository>();

        var mockUserInSessionRepository = new Mock<IUserInSessionRepository>();

        ISessionService service = new SessionService(mockSessionRepository.Object, mockUserInSessionRepository.Object, mockLocationRepository.Object, _mapper);
        await Assert.ThrowsAsync<SessionNotFoundException>(async () => await service.AddUserToSession(createDTO));
    }

    [Fact]
    public async void SessionService_GetUsersInSession_Success()
    {
        var getDTO = new GetUsersInSessionDTO { SessionId = new Guid("24d54b8e-2c1f-4e35-49fb-08db94cbee6d") };

        var mockSessionRepository = new Mock<ISessionRepository>();
        var mockLocation = new Location { Id = new Guid(), Name = "Facing Worlds", LevelFilepath = "levels/face.utm", PosterFilepath = "posters/face.png" };
        var mockSession = new Session { Id = new Guid(), Name = "mockSession", MaxPlayerCount = 16, UserHostId = new Guid(), Level = mockLocation };
        mockSessionRepository.Setup(repository => repository.Get(It.IsAny<Guid>()).Result).Returns(mockSession);

        var mockLocationRepository = new Mock<ILocationRepository>();

        var mockUserInSessionRepository = new Mock<IUserInSessionRepository>();
        var mockUserInSession = new UserInSession { DeathCount = 1, KillCount = 0, Session = mockSession, UserId = new Guid() };
        mockUserInSessionRepository.Setup(repository => repository.GetUsersInParticularSession(mockSession).Result).Returns(new List<UserInSession> { mockUserInSession });

        ISessionService service = new SessionService(mockSessionRepository.Object, mockUserInSessionRepository.Object, mockLocationRepository.Object, _mapper);
        var actual = await service.GetUsersInSession(getDTO);
        mockSessionRepository.Verify(mock => mock.Get(getDTO.SessionId));
        mockUserInSessionRepository.Verify(mock => mock.GetUsersInParticularSession(mockSession));
    }
}
