using System.Net.Http.Headers;
using KP11.Integration.Models.Auth;

namespace KP11.Integration;

public class KP11Client : IClient
{
    public HttpClient HttpClient { get; protected set; }

    public string Token { get; protected set; }

    public KP11Client(string baseAddress)
    {
        HttpClient = new();
        HttpClient.BaseAddress = new Uri(baseAddress);
        InitClient();
    }
    
    public async Task Authorize(ClientAuthConfiguration config)
    {
        string token = await API.Auth.Authorize(HttpClient, config.Login, config.Password);
        Token = token;
        HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }

    public async Task<string> GetAsync(string url)
    {
        return await API.GetAsync(HttpClient, url);
    }

    public async Task<string> PostAsync(string url, string body)
    {
        return await API.PostAsync(HttpClient, url, body);
    }
    
    public async Task<string> PutAsync(string url, string body)
    {
        return await API.PutAsync(HttpClient, url, body);
    }
    
    public async Task<string> DeleteAsync(string url)
    {
        return await API.DeleteAsync(HttpClient, url);
    }

    private void InitClient()
    {
        //HttpClient.DefaultRequestHeaders.Add("Content-Type", "application/json");
        HttpClient.DefaultRequestHeaders.Add("Connection", "keep-alive");
    }
}