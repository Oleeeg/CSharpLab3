using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;

namespace СSharpLab3
{
    class PersonCheckInViewModel : INotifyPropertyChanged
    {
        private readonly Window _mainWindow;
        private string _name;
        private string _lastName;
        private string _email;
        private DateTime _dateOfBirth = DateTime.Today;
        private RelayCommand _signInCommand;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public DateTime DateOfBirth
        {
            get
            {
                return _dateOfBirth;
            }
            set
            {
                _dateOfBirth = value;
                OnPropertyChanged();
            }
        }

        public string BirthDateText { get; set; }

        public RelayCommand RegisterCommand
        {
            get
            {
                return _signInCommand ?? (_signInCommand = new RelayCommand(RegisterImpl,
                           o => !string.IsNullOrWhiteSpace(_name) &&
                                !string.IsNullOrWhiteSpace(_lastName) &&
                                !string.IsNullOrWhiteSpace(_email) &&
                                !string.IsNullOrWhiteSpace(BirthDateText)));
            }
        }

        private async void RegisterImpl(object o)
        {
            Person person = null;
            await Task.Run((() =>
            {
                try
                {
                    person = new Person(_name, _lastName, _email, _dateOfBirth);

                } catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }));
            if (person == null) return;

            if (person.IsBirthday) MessageBox.Show("Hey, you! HAPPY BIRTHDAY!!!");
            PersonResultWindow personInfoWindow = new PersonResultWindow(person);
            _mainWindow.Hide();
            personInfoWindow.Show();

        }

        internal PersonCheckInViewModel(Window mainWindow)
        {
            _mainWindow = mainWindow;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
