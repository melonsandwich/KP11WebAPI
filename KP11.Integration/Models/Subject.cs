using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KP11.Integration.Models;

public class Subject
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }
    public string Name { get; set; }
    public int ProfessorID { get; set; }
}