using AutoMapper;
using Infrastructure.Locations.Mapping;

namespace LocationUnitTests;

public class MappingConfigForTests
{
    public static MapperConfiguration CreateMapperConfig()
    {
        return new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<LocationMapperProfile>();
        });
    }

    public static IMapper CreateMapper()
    {
        return CreateMapperConfig().CreateMapper();
    }
}