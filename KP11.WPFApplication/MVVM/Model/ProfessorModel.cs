using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace KP11.WPFApplication.MVVM.Model
{
    public class ProfessorModel : INotifyPropertyChanged
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
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public string ImageURL
        {
            get => _imageURL;
            set
            {
                _imageURL = value;
                OnPropertyChanged("ImageURL");
            }
        }

        public string Occupation
        {
            get => _occupation;
            set
            {
                _occupation = value;
                OnPropertyChanged("Occupation");
            }
        }

        public string AlmaMater
        {
            get => _almaMater;
            set
            {
                _almaMater = value;
                OnPropertyChanged("AlmaMater");
            }
        }

        public string Speciality
        {
            get => _speciality;
            set
            {
                _speciality = value;
                OnPropertyChanged("Speciality");
            }
        }

        public int WorkExperience
        {
            get => _workExperience;
            set
            {
                _workExperience = value;
                OnPropertyChanged("WorkExperience");
            }
        }

        public int SpecialWorkExperience
        {
            get => _specialWorkExperience;
            set
            {
                _specialWorkExperience = value;
                OnPropertyChanged("SpecialWorkExperience");
            }
        }

        public string? Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }

        public string? Phone
        {
            get => _phone;
            set
            {
                _phone = value;
                OnPropertyChanged("Phone");
            }
        }

        private int _id;
        private string _name;
        private string _imageURL;
        private string _occupation;
        private string _almaMater;
        private string _speciality;
        private int _workExperience;
        private int _specialWorkExperience;
        private string? _email;
        private string? _phone;


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
