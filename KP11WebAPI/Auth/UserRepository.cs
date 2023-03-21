using KP11WebAPI.Models;

namespace KP11WebAPI.Auth;

public class UserRepository : IUserRepository
{
    private List<UserDto> _users => new()
    {
        new UserDto("Penis", "hui"),
        new UserDto("admin", "admin"),
        new UserDto("Sosi", "Huy")
    };
    
    public UserDto GetUser(UserModel userModel)
    {
        return _users.FirstOrDefault(u => 
            string.Equals(u.Login, userModel.Login) && 
            string.Equals(u.Password, userModel.Password)) ??
            throw new Exception("Not found!");
    }
}