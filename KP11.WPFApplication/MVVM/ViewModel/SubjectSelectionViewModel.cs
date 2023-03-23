using KP11.Integration.Models;
using KP11.Integration;
using KP11.WPFApplication.MVVM.Model;
using System.Collections.ObjectModel;
using KP11.WPFApplication.Extensions;

namespace KP11.WPFApplication.MVVM.ViewModel
{
    public class SubjectSelectionViewModel
    {
        public ObservableCollection<SubjectModel> Subjects { get; }

        public ProfessorModel Professor { get; }

        public SubjectSelectionViewModel(ProfessorModel professor)
        {
            Professor = professor;
            Subjects = new();
            PopulateItems();
        }

        private async void PopulateItems()
        {
            foreach (Subject subject in await API.Subjects.GetAllOfProfessor(AppFields.Client.HttpClient, Professor.ID))
            {
                SubjectModel model = subject.ConvertToWPFModel();
                model.ManualAmount = await API.Subjects.GetSubjectsManualAmount(AppFields.Client.HttpClient, model.ID);
                Subjects.Add(model);
            }
        }
    }
}
