using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KP11.Integration.Models;

public class Professor
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }
    
    /// <summary>
    /// ФИО преподавателя
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Фото преподавателя
    /// </summary>
    public string ImageURL { get; set; }
    
    /// <summary>
    /// Занимаемые должности
    /// </summary>
    public string Occupation { get; set; }
    
    /// <summary>
    /// Оконченное учебное заведение
    /// </summary>
    public string AlmaMater { get; set; }
    
    /// <summary>
    /// Специальности
    /// </summary>
    public string Speciality { get; set; }
    
    /// <summary>
    /// Общий стаж работы
    /// </summary>
    public int WorkExperience { get; set; }
    
    /// <summary>
    /// Стаж работы по специальности
    /// </summary>
    public int SpecialWorkExperience { get; set; }
    
    /// <summary>
    /// E-mail
    /// </summary>
    public string? Email { get; set; }
    
    /// <summary>
    /// Телефон
    /// </summary>
    public string? Phone { get; set; }
}