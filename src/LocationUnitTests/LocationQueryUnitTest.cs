using Application.Locations.Interfaces;
using Application.Locations.Queries;
using AutoMapper;
using Moq;

namespace LocationUnitTests;
public class LocationQueryUnitTest
{
    private readonly Mock<ILocationService> _mockLocationService;
    private readonly IMapper _mapper;
    public LocationQueryUnitTest()
    {
        _mapper = MappingConfigForTests.CreateMapper();
        _mockLocationService = new Mock<ILocationService>();
    }

    [Fact]
    public void GetAllLocationsQuery_Success()
    {
        var query = new GetAllLocationsQuery();
        var handler = new GetAllLocationsQueryHandler(_mockLocationService.Object);

        var result = handler.Handle(query, new CancellationToken());

        Assert.NotNull(result);
        _mockLocationService.Verify(mock => mock.GetAll());
    }


}
