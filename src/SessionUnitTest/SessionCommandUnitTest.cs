using Application.Sessions.Commands;
using Application.Sessions.DTO;
using Application.Sessions.Interfaces;
using AutoMapper;
using Moq;

namespace SessionUnitTests;
public class SessionCommandUnitTest
{
    private readonly IMapper _mapper;
    private readonly Mock<ISessionService> _mockSessionService;
    public SessionCommandUnitTest()
    {
        _mapper = MappingConfigForTests.CreateMapper();
        _mockSessionService = new Mock<ISessionService>();
    }

    [Fact]
    public void CreateSessionCommand_Success()
    {
        var cmd = new CreateSessionCommand { MaxPlayerCount = 4, Name = "oleg", UserHostId = new Guid("13d54b8e-2c1f-4e35-49fb-08db94cbee6d"), LevelId = new Guid("13d54b8e-2c1f-4e35-49fb-08db94cbee6d") };
        var handler = new CreateSessionCommandHandler(_mockSessionService.Object, _mapper);

        var result = handler.Handle(cmd, new CancellationToken());

        Assert.NotNull(result);
        _mockSessionService.Verify(mock => mock.Create(_mapper.Map<CreateSessionDTO>(cmd)));
    }

    [Fact]
    public void AddUserToSessionCommand_Success()
    {
        var cmd = new AddUserToSessionCommand { UserId = new Guid("13d54b8e-2c1f-4e35-49fb-08db94cbee6d"), SessionId = new Guid("13d54b8e-2c1f-4e35-49fb-08db94cbee6d") };
        var handler = new AddUserToSessionCommandHandler(_mockSessionService.Object, _mapper);

        var result = handler.Handle(cmd, new CancellationToken());

        Assert.NotNull(result);
        _mockSessionService.Verify(mock => mock.AddUserToSession(_mapper.Map<AddUserToSessionDTO>(cmd)));
    }
}
