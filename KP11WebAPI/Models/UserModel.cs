using System.ComponentModel.DataAnnotations;

namespace KP11WebAPI.Models;

public class UserModel
{
    [Required]
    public string Login { get; set; }
    
    [Required]
    public string Password { get; set; }
}