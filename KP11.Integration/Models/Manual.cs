using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KP11.Integration.Models;

public class Manual
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }
    public string Name { get; set; }
    public string ContentLink { get; set; }
    public int SubjectID { get; set; }
}