using Application.Locations.Commands;
using Application.Locations.DTO;
using AutoMapper;
using Domain.Entities;

namespace LocationUnitTests;

public class LocationMappingUnitTests
{
    private readonly IMapper _mapper;

    public LocationMappingUnitTests()
    {
        _mapper = MappingConfigForTests.CreateMapper();
    }
    public static IEnumerable<object[]> LocationEntitiesComplete
    {
        get
        {
            return new[]
            {
                new object[] { new Location { Id = new Guid(), Name = "Facing Worlds", LevelFilepath = "levels/face.utm", PosterFilepath = "posters/face.png" } },
                new object[] { new Location { Id = new Guid(), Name = "Crane", LevelFilepath = "levels/crane.utm", PosterFilepath = "posters/crane.png" } }
            };
        }
    }

    public static IEnumerable<object[]> LocationCreateDTOsComplete
    {
        get
        {
            return new[]
            {
                new object[] { new CreateLocationDTO { Name = "Facing Worlds", LevelFilepath = "levels/face.utm", PosterFilepath = "posters/face.png" } },
                new object[] { new CreateLocationDTO { Name = "Crane", LevelFilepath = "levels/crane.utm", PosterFilepath = "posters/crane.png" } }
            };
        }
    }

    public static IEnumerable<object[]> LocationCreateCommandsComplete
    {
        get
        {
            return new[]
            {
                new object[] { new CreateLocationCommand { Name = "Facing Worlds", LevelFilepath = "levels/face.utm", PosterFilepath = "posters/face.png" } },
                new object[] { new CreateLocationCommand { Name = "Crane", LevelFilepath = "levels/crane.utm", PosterFilepath = "posters/crane.png" } }
            };
        }
    }

    [Fact]
    public void Automapper_Configuration_SuccessInit()
    {
        var config = MappingConfigForTests.CreateMapperConfig();
        config.AssertConfigurationIsValid();
    }

    [Theory, MemberData(nameof(LocationEntitiesComplete))]
    public void LocationMapper_ConvertToViewDTO_SuccessFieldConverting(Location entity)
    {
        var expected = new ViewLocationDTO { Id = entity.Id.ToString(), Name = entity.Name };
        var actual = _mapper.Map<ViewLocationDTO>(entity);

        Assert.Equal(expected.Name, actual.Name);
        Assert.Equal(expected.Id, actual.Id);
    }

    [Theory, MemberData(nameof(LocationCreateDTOsComplete))]
    public void LocationMapper_ConvertToEntity_SuccessFieldConverting(CreateLocationDTO createDTO)
    {
        var expected = new Location { Name = createDTO.Name, LevelFilepath = createDTO.LevelFilepath, PosterFilepath = createDTO.PosterFilepath };
        var actual = _mapper.Map<Location>(createDTO);

        Assert.Equal(expected.Name, actual.Name);
        Assert.Equal(expected.LevelFilepath, actual.LevelFilepath);
        Assert.Equal(expected.PosterFilepath, actual.PosterFilepath);
    }

    [Theory, MemberData(nameof(LocationCreateCommandsComplete))]
    public void LocationMapper_ConvertToDTO_SuccessFieldConverting(CreateLocationCommand createDTO)
    {
        var expected = new CreateLocationDTO { Name = createDTO.Name, LevelFilepath = createDTO.LevelFilepath, PosterFilepath = createDTO.PosterFilepath };
        var actual = _mapper.Map<CreateLocationDTO>(createDTO);

        Assert.Equal(expected.Name, actual.Name);
        Assert.Equal(expected.LevelFilepath, actual.LevelFilepath);
        Assert.Equal(expected.PosterFilepath, actual.PosterFilepath);
    }
}
