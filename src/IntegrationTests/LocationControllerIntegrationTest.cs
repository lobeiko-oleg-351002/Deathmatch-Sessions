using Application.Locations.Commands;
using Newtonsoft.Json;

namespace IntegrationTests;

public class LocationControllerIntegrationTest : IClassFixture<TestingWebAppFactory<Program>>
{
    private readonly HttpClient _client;
    public LocationControllerIntegrationTest(TestingWebAppFactory<Program> factory)
        => _client = factory.CreateClient();

    public static IEnumerable<object[]> LocationCreateCommands
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

    [Theory, MemberData(nameof(LocationCreateCommands))]
    public async Task CreateLocation_Success(CreateLocationCommand cmd)
    {
        var postRequest = new HttpRequestMessage(HttpMethod.Post, "/Location/CreateLocation");

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
