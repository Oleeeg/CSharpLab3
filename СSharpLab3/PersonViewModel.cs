using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace СSharpLab3
{
    class PersonViewModel : INotifyPropertyChanged
    {
        private readonly Person _person;
        public string Name => "Name : " + _person.Name;
        public string LastName => "Last name : " + _person.LastName;
        public string Email => "Email : " + _person.Email;
        public string DateOfBirth => "Date of birth : " + _person.DateOfBirth.ToShortDateString();
        public string SunSign => "Sun sign : " + _person.SunSign;
        public string ChineseSign => "Chinese sign : " + _person.ChineseSign;
        public string IsBirthday => CheckOutBirthday();
        public string IsAdult => CheckOut18();

        public PersonViewModel(Person person)
        {
            _person = person;
        }

        private string CheckOutBirthday()
        {
            if (_person.IsBirthday) return "Today is your birthday!";
            else return "Today is not your birthday!";
        }

        private string CheckOut18()
        {
            if (_person.IsAdult) return "You are grown up now! Congrats!!!";
            else return "You're not a grown up! You're under 18.";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}