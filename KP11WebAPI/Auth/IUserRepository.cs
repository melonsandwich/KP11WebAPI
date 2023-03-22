using KP11.Integration.Models;

namespace KP11WebAPI.Auth;

public interface IUserRepository
{
    UserDto GetUser(UserModel userModel);
}