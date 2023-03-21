namespace KP11WebAPI.Auth;

public class UserDto
{
    public string Login { get; set; }
    public string Password { get; set; }

    public UserDto(string login, string password)
    {
        Login = login;
        Password = password;
    }
}