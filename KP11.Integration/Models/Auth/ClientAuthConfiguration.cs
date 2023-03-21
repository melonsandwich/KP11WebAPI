namespace KP11.Integration.Models.Auth;

public class ClientAuthConfiguration
{
    public string Login { get; set; }
    public string Password { get; set; }
    
    public ClientAuthConfiguration() {}

    public ClientAuthConfiguration(string login, string password)
    {
        Login = login;
        Password = password;
    }
}