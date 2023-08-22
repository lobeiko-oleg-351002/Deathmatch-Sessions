using Application.Locations.DTO;
using Application.Locations.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Common.Exceptions;
using Infrastructure.Locations.Services;
using Moq;

namespace LocationUnitTests;
public class LocationServiceUnitTest
{
    private readonly IMapper _mapper;
    public LocationServiceUnitTest()
    {
        _mapper = MappingConfigForTests.CreateMapper();
    }

    [Fact]
    public async void LocationService_Create_Success()
    {
        var createDTO = new CreateLocationDTO { Name = "Facing Worlds", LevelFilepath = "levels/face.utm", PosterFilepath = "posters/face.png" };
        var expected = new ViewLocationDTO() { Id = new Guid(), Name = createDTO.Name };

        var entity = _mapper.Map<Location>(createDTO);


        var mockLocationRepository = new Mock<ILocationRepository>();
        mockLocationRepository.Setup(repository => repository.Create(It.Is<Location>(Location => Location.Name == entity.Name)).Result).Returns(entity);


        ILocationService service = new LocationService(mockLocationRepository.Object, _mapper);
        var actual = await service.Create(createDTO);
        Assert.Equal(expected.Name, actual.Name);
    }

    [Fact]
    public async void LocationService_Create_FailedOnRepositoryException()
    {
        var createDTO = new CreateLocationDTO { Name = "Facing Worlds", LevelFilepath = "levels/face.utm", PosterFilepath = "posters/face.png" };

        var mockLocationRepository = new Mock<ILocationRepository>();
        mockLocationRepository.Setup(repository => repository.Create(It.IsAny<Location>())).Throws(new DalCreateException("mock exception"));


        ILocationService service = new LocationService(mockLocationRepository.Object, _mapper);
        await Assert.ThrowsAsync<DalCreateException>(async () => await service.Create(createDTO));
    }
}
