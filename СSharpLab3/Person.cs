using System;
using System.Text.RegularExpressions;
using System.Windows;
using static СSharpLab3.PersonException;

namespace СSharpLab3
{
    public class Person
    {
        private string _name;
        private string _lastName;
        private string _email;
        private DateTime _dateOfBirth;

        private static String[] chineseHor = { "Monkey", "Rooster", "Dog", "Pig", "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat", };
        private static String[] sunSign = { "Aries", "Taurus", "Gemini", "Cancer", "Leo", "Virgo", "Libra", "Scorpio", "Sagittarius", "Capricorn", "Aquarius", "Pieces" };

        public bool IsAdult => isAdultAlready();
        public bool IsBirthday => IsBirthdayToday();
        public string ChineseSign => findChineseSign();
        public string SunSign => findSunSign();

        public Person(string name, string lastName, string email, DateTime dateOfBirth)
        {
            if ((name.Length < 2) | (Regex.IsMatch(name, "[^a-zA-Z]"))) throw new InvalidNameException(name);
            else
            {
                if ((lastName.Length < 2) | (Regex.IsMatch(lastName, "[^a-zA-Z]"))) throw new InvalidLastNameException(lastName);
                else
                {
                    if (!Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")) throw new InvalidEmailAddressException(email);
                    else
                    { if (FutureDate(dateOfBirth)) throw new InvalidFDate(dateOfBirth);
                        else
                        {
                            if (Dead(dateOfBirth)) throw new InvalidDDate(dateOfBirth);
                            else {
                                _name = name;
                                _lastName = lastName;
                                _email = email;
                                _dateOfBirth = dateOfBirth;
                            }
                        }
                    }
                }
            }
        }

        public Person(string name, string lastName, string email)
        {
            if ((name.Length < 2) | (Regex.IsMatch(name, "[^a-zA-Z]"))) throw new InvalidNameException(name);
            else
            {
                if ((lastName.Length < 2) | (Regex.IsMatch(lastName, "[^a-zA-Z]"))) throw new InvalidLastNameException(lastName);
                else
                {
                    if (!Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")) throw new InvalidEmailAddressException(email);
                    else
                    {
                        _name = name;
                        _lastName = lastName;
                        _email = email;
                        _dateOfBirth = DateTime.Today;
                    }
                }
            }
        }

        public Person(string name, string lastName, DateTime dateOfBirth)
        {
            if ((name.Length < 2) | (Regex.IsMatch(name, "[^a-zA-Z]"))) throw new InvalidNameException(name);
            else
            {
                if ((lastName.Length < 2) | (Regex.IsMatch(lastName, "[^a-zA-Z]"))) throw new InvalidLastNameException(lastName);
                else
                {
                    if (FutureDate(dateOfBirth)) throw new InvalidFDate(dateOfBirth);
                    else
                    {
                        if (Dead(dateOfBirth)) throw new InvalidDDate(dateOfBirth);
                        else
                        {
                            _name = name;
                            _lastName = lastName;
                            _email = "no info";
                            _dateOfBirth = dateOfBirth;
                        }
                    }
                }
            }
        }

        internal string Name
        {
            get { return _name; }
            private set
            {
                _name = value;
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
            }
        }

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            private set
            {
                _dateOfBirth = value;
            }
        }

        private bool isAdultAlready()
        {
            DateTime today = DateTime.Today;
            int age = today.Year - DateOfBirth.Year;
            if (today.DayOfYear < DateOfBirth.DayOfYear) age--;
            return age >= 18;
        }

        private bool IsBirthdayToday()
        {
            DateTime today = DateTime.Today;
            return today.DayOfYear == DateOfBirth.DayOfYear;
        }

        private string findChineseSign()
        {
            return chineseHor[_dateOfBirth.Year % 12];
        }

        private string findSunSign()
        {
            string sign = "";
            if (((_dateOfBirth.Month == 1) && (_dateOfBirth.Day >= 20 && (_dateOfBirth.Day <= 31)) || ((_dateOfBirth.Month == 2) && (_dateOfBirth.Day >= 1 && _dateOfBirth.Day <= 17)))) sign = sunSign[10];
            if (((_dateOfBirth.Month == 2) && (_dateOfBirth.Day >= 18 && (_dateOfBirth.Day <= 28)) || ((_dateOfBirth.Month == 3) && (_dateOfBirth.Day >= 1 && _dateOfBirth.Day <= 19)))) sign = sunSign[11];
            if (((_dateOfBirth.Month == 3) && (_dateOfBirth.Day >= 20 && (_dateOfBirth.Day <= 31)) || ((_dateOfBirth.Month == 4) && (_dateOfBirth.Day >= 1 && _dateOfBirth.Day <= 19)))) sign = sunSign[0];
            if (((_dateOfBirth.Month == 4) && (_dateOfBirth.Day >= 20 && (_dateOfBirth.Day <= 30)) || ((_dateOfBirth.Month == 5) && (_dateOfBirth.Day >= 1 && _dateOfBirth.Day <= 20)))) sign = sunSign[1];
            if (((_dateOfBirth.Month == 5) && (_dateOfBirth.Day >= 21 && (_dateOfBirth.Day <= 31)) || ((_dateOfBirth.Month == 6) && (_dateOfBirth.Day >= 1 && _dateOfBirth.Day <= 20)))) sign = sunSign[2];
            if (((_dateOfBirth.Month == 6) && (_dateOfBirth.Day >= 21 && (_dateOfBirth.Day <= 30)) || ((_dateOfBirth.Month == 7) && (_dateOfBirth.Day >= 1 && _dateOfBirth.Day <= 22)))) sign = sunSign[3];
            if (((_dateOfBirth.Month == 7) && (_dateOfBirth.Day >= 23 && (_dateOfBirth.Day <= 31)) || ((_dateOfBirth.Month == 8) && (_dateOfBirth.Day >= 1 && _dateOfBirth.Day <= 22)))) sign = sunSign[4];
            if (((_dateOfBirth.Month == 8) && (_dateOfBirth.Day >= 23 && (_dateOfBirth.Day <= 31)) || ((_dateOfBirth.Month == 9) && (_dateOfBirth.Day >= 1 && _dateOfBirth.Day <= 22)))) sign = sunSign[5];
            if (((_dateOfBirth.Month == 9) && (_dateOfBirth.Day >= 23 && (_dateOfBirth.Day <= 30)) || ((_dateOfBirth.Month == 10) && (_dateOfBirth.Day >= 1 && _dateOfBirth.Day <= 22)))) sign = sunSign[6];
            if (((_dateOfBirth.Month == 10) && (_dateOfBirth.Day >= 23 && (_dateOfBirth.Day <= 31)) || ((_dateOfBirth.Month == 11) && (_dateOfBirth.Day >= 1 && _dateOfBirth.Day <= 21)))) sign = sunSign[7];
            if (((_dateOfBirth.Month == 11) && (_dateOfBirth.Day >= 22 && (_dateOfBirth.Day <= 30)) || ((_dateOfBirth.Month == 12) && (_dateOfBirth.Day >= 1 && _dateOfBirth.Day <= 19)))) sign = sunSign[8];
            if (((_dateOfBirth.Month == 12) && (_dateOfBirth.Day >= 20 && (_dateOfBirth.Day <= 31)) || ((_dateOfBirth.Month == 1) && (_dateOfBirth.Day >= 1 && _dateOfBirth.Day <= 19)))) sign = sunSign[9];
            return sign;
        }


        public bool Dead(DateTime dateOfBirth)
        {
            if ((DateTime.Today.Year - dateOfBirth.Year) > 135) return true;
            else return false;
        }

        public bool FutureDate(DateTime dateOfBirth)
        {
            bool valid = false;
            if (DateTime.Today.Year == dateOfBirth.Year)
            {
                if (DateTime.Today.DayOfYear < dateOfBirth.DayOfYear) return valid = true;
            }
            return valid;
        }
    }
}