﻿using Application.Sessions.DTO;
using Application.Sessions.Interfaces;
using Newtonsoft.Json;
using System.Net.Http;

namespace Infrastructure.Sessions.Services;

public class UserExternalService : IUserExternalService
{
    private readonly IHttpClientFactory _httpClientFactory;
    public UserExternalService(IHttpClientFactory httpClientFactory) 
    {
        _httpClientFactory = httpClientFactory;
    }  
    public async Task<ViewUserDTO> GetUser(Guid id)
    {

        using (var client = _httpClientFactory?.CreateClient())
        {
            var result = await client.GetAsync("https://localhost:7227/User/Get" + $"?Id={id}");
            var content = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ViewUserDTO>(content);
        }
    }
}
