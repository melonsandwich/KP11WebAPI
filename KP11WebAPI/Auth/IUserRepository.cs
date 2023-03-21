using KP11WebAPI.Models;

namespace KP11WebAPI.Auth;

public interface IUserRepository
{
    UserDto GetUser(UserModel userModel);
}