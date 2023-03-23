using KP11.Integration.Models;
using KP11.WPFApplication.MVVM.Model;

namespace KP11.WPFApplication.Extensions
{
    public static class ProfessorExtensions
    {
        public static ProfessorModel ConvertToWPFModel(this Professor professor)
        {
            ProfessorModel model = new()
            {
                ID = professor.ID,
                Name = professor.Name,
                ImageURL = professor.ImageURL,
                Occupation = professor.Occupation,
                AlmaMater = professor.AlmaMater,
                Speciality = professor.Speciality,
                WorkExperience = professor.WorkExperience,
                SpecialWorkExperience = professor.SpecialWorkExperience,
                Email = professor.Email,
                Phone = professor.Phone
            };
            return model;
        }

        public static Professor ConvertToAPIModel(this ProfessorModel professor)
        {
            Professor model = new()
            {
                ID = professor.ID,
                Name = professor.Name,
                ImageURL = professor.ImageURL,
                Occupation = professor.Occupation,
                AlmaMater = professor.AlmaMater,
                Speciality = professor.Speciality,
                WorkExperience = professor.WorkExperience,
                SpecialWorkExperience = professor.SpecialWorkExperience,
                Email = professor.Email,
                Phone = professor.Phone
            };
            return model;
        }
    }
}
