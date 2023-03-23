using KP11.Integration.Models;
using KP11.WPFApplication.MVVM.Model;

namespace KP11.WPFApplication.Extensions
{
    public static class SubjectExtensions
    {
        public static SubjectModel ConvertToWPFModel(this Subject subject)
        {
            SubjectModel model = new()
            {
                ID = subject.ID,
                Name = subject.Name,
                ProfessorID = subject.ProfessorID
            };
            return model;
        }

        public static Subject ConvertToAPIModel(this SubjectModel subject)
        {
            Subject model = new()
            {
                ID = subject.ID,
                Name = subject.Name,
                ProfessorID = subject.ProfessorID
            };
            return model;
        }
    }
}
