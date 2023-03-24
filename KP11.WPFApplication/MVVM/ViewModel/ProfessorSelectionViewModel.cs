using KP11.Integration;
using KP11.Integration.Models;
using KP11.WPFApplication.Extensions;
using KP11.WPFApplication.MVVM.Model;
using System;
using System.Collections.ObjectModel;

namespace KP11.WPFApplication.MVVM.ViewModel
{
    public class ProfessorSelectionViewModel
    {
        public event Action? FinishedPopulating;

        public ObservableCollection<ProfessorModel> Professors { get; set; }

        public ProfessorSelectionViewModel()
        {
            Professors = new();
            PopulateItems();
        }

        private async void PopulateItems()
        {
            foreach (Professor professor in await API.Professors.GetAll(AppFields.Client.HttpClient))
            {
                Professors.Add(professor.ConvertToWPFModel());
            }
            FinishedPopulating?.Invoke();
        }

        public void Update()
        {
            Professors.Clear();
            PopulateItems();
        }
    }
}
