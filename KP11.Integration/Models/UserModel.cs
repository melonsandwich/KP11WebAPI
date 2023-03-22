using System.ComponentModel.DataAnnotations;

namespace KP11.Integration.Models;

public class UserModel
{
    [Required]
    public string Login { get; set; }
    
    [Required]
    public string Password { get; set; }
}