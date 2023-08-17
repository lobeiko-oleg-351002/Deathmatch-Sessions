using Application.Locations.Commands;
using Application.Locations.DTO;
using Application.Locations.Interfaces;
using AutoMapper;
using Moq;

namespace LocationUnitTests;
public class LocationCommandUnitTest
{
    private readonly IMapper _mapper;
    private readonly Mock<ILocationService> _mockLocationService;
    public LocationCommandUnitTest()
    {
        _mapper = MappingConfigForTests.CreateMapper();
        _mockLocationService = new Mock<ILocationService>();
    }

    [Fact]
    public void CreateLocationCommand_Success()
    {
        var cmd = new CreateLocationCommand { Name = "Facing Worlds", LevelFilepath = "levels/face.utm", PosterFilepath = "posters/face.png" };
        var handler = new CreateLocationCommandHandler(_mockLocationService.Object, _mapper);

        var result = handler.Handle(cmd, new CancellationToken());

        Assert.NotNull(result);
        _mockLocationService.Verify(mock => mock.Create(_mapper.Map<CreateLocationDTO>(cmd)));
    }
}
