using KP11.Integration.Models;
using KP11.WPFApplication.MVVM.Model;

namespace KP11.WPFApplication.Extensions
{
    public static class ManualExtensions
    {
        public static ManualModel ConvertToWPFModel(this Manual manual)
        {
            ManualModel model = new()
            {
                ID = manual.ID,
                Name = manual.Name,
                ContentLink = manual.ContentLink,
                SubjectID = manual.SubjectID
            };
            return model;
        }

        public static Manual ConvertToAPIModel(this ManualModel manual)
        {
            Manual model = new()
            {
                ID = manual.ID,
                Name = manual.Name,
                ContentLink = manual.ContentLink,
                SubjectID = manual.SubjectID
            };
            return model;
        }
    }
}
