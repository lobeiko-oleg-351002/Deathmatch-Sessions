﻿using Application.Sessions.Commands;
using Application.Sessions.DTO;
using AutoMapper;
using Domain.Entities;

namespace SessionUnitTests;

public class SessionMappingUnitTests
{
    private readonly IMapper _mapper;

    private static readonly Location _testLocation = new Location { Name = "location", LevelFilepath = "/path/loc", PosterFilepath = "/path/poster.png" };

    public SessionMappingUnitTests()
    {
        _mapper = MappingConfigForTests.CreateMapper();
    }
    public static IEnumerable<object[]> SessionEntitiesComplete
    {
        get
        {
            return new[]
            {
                new object[] { new Session { Id = new Guid(), MaxPlayerCount = 4, Name = "oleg", UserHostId = new Guid(), Level = _testLocation  } },
                new object[] { new Session { Id = new Guid(), MaxPlayerCount = 12, Name = "ttt123", UserHostId = new Guid(), Level = _testLocation } }
            };
        }
    }

    public static IEnumerable<object[]> SessionCreateCommandsComplete
    {
        get
        {
            return new[]
            {
                new object[] { new CreateSessionCommand { MaxPlayerCount = 4, Name = "oleg", UserHostId = "13d54b8e-2c1f-4e35-49fb-08db94cbee6d", LevelId = "13d54b8e-2c1f-4e35-49fb-08db94cbee6d"  } },
                new object[] { new CreateSessionCommand { MaxPlayerCount = 12, Name = "ttt123", UserHostId = "13d54b8e-2c1f-4e35-49fb-08db94cbee6d", LevelId = "13d54b8e-2c1f-4e35-49fb-08db94cbee6d" } }
            };
        }
    }

    [Fact]
    public void Automapper_Configuration_SuccessInit()
    {
        var config = MappingConfigForTests.CreateMapperConfig();
        config.AssertConfigurationIsValid();
    }

    [Theory, MemberData(nameof(SessionEntitiesComplete))]
    public void SessionMapper_ConvertToViewDTO_SuccessFieldConverting(Session entity)
    {
        var expected = new ViewSessionDTO { Id = entity.Id.ToString(), Name = entity.Name };
        var actual = _mapper.Map<ViewSessionDTO>(entity);

        Assert.Equal(expected.Name, actual.Name);
        Assert.Equal(expected.Id, actual.Id);
    }

    [Theory, MemberData(nameof(SessionCreateCommandsComplete))]
    public void SessionMapper_ConvertToDTO_SuccessFieldConverting(CreateSessionCommand createDTO)
    {
        var expected = new CreateSessionDTO { MaxPlayerCount = createDTO.MaxPlayerCount, Name = createDTO.Name, UserHostId = createDTO.UserHostId, LevelId = createDTO.LevelId };
        var actual = _mapper.Map<CreateSessionDTO>(createDTO);

        Assert.Equal(expected.Name, actual.Name);
        Assert.Equal(expected.UserHostId, actual.UserHostId);
        Assert.Equal(expected.LevelId, actual.LevelId);
        Assert.Equal(expected.MaxPlayerCount, actual.MaxPlayerCount);
    }
}
