using KP11.Integration.Models;
using KP11.Integration;
using KP11.WPFApplication.MVVM.Model;
using System.Collections.ObjectModel;
using KP11.WPFApplication.Extensions;
using System;

namespace KP11.WPFApplication.MVVM.ViewModel
{
    public class ManualSelectionViewModel
    {
        public event Action? FinishedPopulating;

        public ObservableCollection<ManualModel> Manuals { get; }

        public SubjectModel Subject { get; }

        public ManualSelectionViewModel(SubjectModel subject)
        {
            Manuals = new();
            Subject = subject;
            PopulateItems();
        }

        private async void PopulateItems()
        {
            foreach (Manual manual in await API.Manuals.GetAllOfSubject(AppFields.Client.HttpClient, Subject.ID))
            {
                Manuals.Add(manual.ConvertToWPFModel());
            }
            FinishedPopulating?.Invoke();
        }

        public void Update()
        {
            Manuals.Clear();
            PopulateItems();
        }
    }
}
