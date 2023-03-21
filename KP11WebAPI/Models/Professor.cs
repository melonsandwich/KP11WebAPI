using System.ComponentModel.DataAnnotations;

namespace KP11WebAPI.Models;

public class Professor
{
    [Required]
    public int ID { get; set; }
}