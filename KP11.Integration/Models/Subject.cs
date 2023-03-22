using System.ComponentModel.DataAnnotations;

namespace KP11.Integration.Models;

public class Subject
{
    [Required]
    public int ID { get; set; }
    public string Name { get; set; }
    public int ProfessorID { get; set; }
}