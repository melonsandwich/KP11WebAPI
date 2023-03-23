using KP11.Integration;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace KP11.WPFApplication.MVVM.Model
{
    public class SubjectModel : INotifyPropertyChanged
    {
        public int ID
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged("ID");
            }
        }

        public string Name
        {
            get => _name ?? throw new Exception("Exception");
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public int ProfessorID
        {
            get => _professorID;
            set
            {
                _professorID = value;
                OnPropertyChanged("ProfessorID");
            }
        }

        public SubjectModel()
        {
            GetManualAmount();
        }

        public int ManualAmount
        {
            get => _manualAmount;
            set
            {
                _manualAmount = value;
                OnPropertyChanged("ManualAmount");
            }
        }

        private int _id;
        private string? _name;
        private int _professorID;
        private int _manualAmount;

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private async void GetManualAmount()
        {
            ManualAmount = await API.Subjects.GetSubjectsManualAmount(AppFields.Client.HttpClient, ID);
        }
    }
}
