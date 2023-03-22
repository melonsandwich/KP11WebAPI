using System.ComponentModel.DataAnnotations;

namespace KP11.Integration.Models;

public class Manual
{
    [Required]
    public int ID { get; set; }
    public string Name { get; set; }
    public string ContentLink { get; set; }
    
    public int SubjectID { get; set; }
}