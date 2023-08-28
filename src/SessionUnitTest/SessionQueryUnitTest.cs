using Application.Sessions.DTO;
using Application.Sessions.Interfaces;
using Application.Sessions.Queries;
using AutoMapper;
using Moq;

namespace SessionUnitTests;
public class SessionQueryUnitTest
{
    private readonly IMapper _mapper;
    private readonly Mock<ISessionService> _mockSessionService;
    public SessionQueryUnitTest()
    {
        _mapper = MappingConfigForTests.CreateMapper();
        _mockSessionService = new Mock<ISessionService>();
    }

    [Fact]
    public void GetAllSessionsQuery_Success()
    {
        var query = new GetAllSessionsQuery();
        var handler = new GetAllSessionsQueryHandler(_mockSessionService.Object);

        var result = handler.Handle(query, new CancellationToken());

        Assert.NotNull(result);
        _mockSessionService.Verify(mock => mock.GetAll());
    }

    [Fact]
    public void GetPlayerProfilesInSessionQuery_Success()
    {
        var cmd = new GetPlayerProfilesInSessionQuery { SessionId = new Guid("13d54b8e-2c1f-4e35-49fb-08db94cbee6d") };
        var handler = new GetPlayerProfilesInSessionQueryHandler(_mockSessionService.Object, _mapper);

        var result = handler.Handle(cmd, new CancellationToken());

        Assert.NotNull(result);
        _mockSessionService.Verify(mock => mock.GetProfilesInSession(_mapper.Map<GetPlayerProfilesInSessionDTO>(cmd)));
    }
}
