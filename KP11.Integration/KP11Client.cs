using KP11.Integration.Models.Auth;

namespace KP11.Integration;

public class KP11Client : IClient
{
    public HttpClient HttpClient { get; set; }

    private string _token = string.Empty;

    public KP11Client()
    {
        HttpClient = new();
    }
    
    public Task Authorize(ClientAuthConfiguration config)
    {
        throw new NotImplementedException();
    }
}