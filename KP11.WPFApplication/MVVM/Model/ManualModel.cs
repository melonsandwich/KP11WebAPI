using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace KP11.WPFApplication.MVVM.Model
{
    public class ManualModel : INotifyPropertyChanged
    {
        public int ID
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(ID));
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string ContentLink
        {
            get => _contentLink;
            set
            {
                _contentLink = value;
                OnPropertyChanged(nameof(ContentLink));
            }
        }

        public int SubjectID
        {
            get => _subjectID;
            set
            {
                _subjectID = value;
                OnPropertyChanged(nameof(SubjectID));
            }
        }

        private int _id;
        private string _name;
        private string _contentLink;
        private int _subjectID;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
