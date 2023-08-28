using Application.Sessions.Commands;
using Newtonsoft.Json;

namespace IntegrationTests;

public class SessionControllerIntegrationTest : IClassFixture<TestingWebAppFactory<Program>>
{
    private readonly HttpClient _client;
    public SessionControllerIntegrationTest(TestingWebAppFactory<Program> factory)
        => _client = factory.CreateClient();

    public static IEnumerable<object[]> SessionCreateCommands
    {
        get
        {
            return new[]
            {
                new object[] { new CreateSessionCommand { MaxPlayerCount = 4, Name = "oleg", UserHostId = new Guid("13d54b8e-2c1f-4e35-49fb-08db94cbee6d"), LevelId = new Guid("23d54b8e-2c1f-4e35-49fb-08db94cbee6d")  } },
                new object[] { new CreateSessionCommand { MaxPlayerCount = 12, Name = "ttt123", UserHostId = new Guid("13d54b8e-2c1f-4e35-49fb-08db94cbee6d"), LevelId = new Guid("23d54b8e-2c1f-4e35-49fb-08db94cbee6d") } }
            };
        }
    }

    public static IEnumerable<object[]> AddUserToSessionCommands
    {
        get
        {
            return new[]
            {
                new object[] { new AddProfileToSessionCommand { ProfileId = new Guid("13d54b8e-2c1f-4e35-49fb-08db94cbee6d"), SessionId = new Guid("24d54b8e-2c1f-4e35-49fb-08db94cbee6d") } },
            };
        }
    }

    [Theory, MemberData(nameof(SessionCreateCommands))]
    public async Task CreateSession_Success(CreateSessionCommand cmd)
    {
        var postRequest = new HttpRequestMessage(HttpMethod.Post, "/session");

        var cmdDictionary = ToDictionary<string>(cmd);

        postRequest.Content = new FormUrlEncodedContent(cmdDictionary);

        var response = await _client.SendAsync(postRequest);

        response.EnsureSuccessStatusCode();
    }

    [Theory, MemberData(nameof(AddUserToSessionCommands))]
    public async Task AddUserToSession_Success(AddProfileToSessionCommand cmd)
    {
        var postRequest = new HttpRequestMessage(HttpMethod.Post, "/sessions/user");

        var cmdDictionary = ToDictionary<string>(cmd);

        postRequest.Content = new FormUrlEncodedContent(cmdDictionary);

        var response = await _client.SendAsync(postRequest);

        response.EnsureSuccessStatusCode();
    }

    private static Dictionary<string, TValue> ToDictionary<TValue>(object obj)
    {
        var json = JsonConvert.SerializeObject(obj);
        var dictionary = JsonConvert.DeserializeObject<Dictionary<string, TValue>>(json);
        return dictionary;
    }
}
