using AutoMapper;
using Infrastructure.Sessions.Mapping;

namespace SessionUnitTests;

public class MappingConfigForTests
{
    public static MapperConfiguration CreateMapperConfig()
    {
        return new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<SessionMapperProfile>(); 
            cfg.AddProfile<ProfileInSessionMapperProfile>();
        });
    }

    public static IMapper CreateMapper()
    {
        return CreateMapperConfig().CreateMapper();
    }
}