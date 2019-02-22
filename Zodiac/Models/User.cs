using System;

namespace Zodiac.Models
{
    internal class User
    {
        private DateTime _birthDate;
        internal string Age { get; private set; }
        internal string WesternSign { get; private set; }
        internal string ChineseSign { get; private set; }
        internal bool Executable { get; private set; }
        private readonly string[] _westernSigns = { "Capricorn", "Aquarius", "Pisces", "Aries", "Taurus", "Gemini", "Cancer", "Leo", "Virgo", "Libra", "Scorpio", "Sagittarius" };
        private readonly string[] _chineseSigns = { "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat", "Monkey", "Rooster", "Dog", "Pig" };

        internal User()
        {
            _birthDate = DateTime.Today;
        }

        public bool Congrats => DateTime.Today.Month == _birthDate.Month && DateTime.Today.Day == _birthDate.Day;

        public DateTime BirthDate
        {
            get { return _birthDate; }
            set
            {
                _birthDate = value;
                var age = (DateTime.Today.Year - value.Year) - (DateTime.Today.DayOfYear >= _birthDate.DayOfYear ? 0 : 1);
                var diff = DateTime.Today - value;
                Executable = diff.Days >= 0 && age <= 135;

                if ( Executable )
                {
                    Age = age > 0 ? age + " year(s)" : diff.Days + " day(s)";
                    ChineseSign = _chineseSigns[(_birthDate.Year + 8) % 12];
                    var bmonth = _birthDate.Month;
                    var bday = _birthDate.Day;
                    switch (bmonth)
                    {
                        case 1:
                            WesternSign = bday >= 20 ? _westernSigns[1] : _westernSigns[0];
                            break;
                        case 2:
                            WesternSign = bday >= 19 ? _westernSigns[2] : _westernSigns[1];
                            break;
                        case 3:
                            WesternSign = bday >= 21 ? _westernSigns[3] : _westernSigns[2];
                            break;
                        case 4:
                            WesternSign = bday >= 20 ? _westernSigns[4] : _westernSigns[3];
                            break;
                        case 5:
                            WesternSign = bday >= 21 ? _westernSigns[5] : _westernSigns[4];
                            break;
                        case 6:
                            WesternSign = bday >= 21 ? _westernSigns[6] : _westernSigns[5];
                            break;
                        case 7:
                            WesternSign = bday >= 23 ? _westernSigns[7] : _westernSigns[6];
                            break;
                        case 8:
                            WesternSign = bday >= 23 ? _westernSigns[8] : _westernSigns[7];
                            break;
                        case 9:
                            WesternSign = bday >= 23 ? _westernSigns[9] : _westernSigns[8];
                            break;
                        case 10:
                            WesternSign = bday >= 23 ? _westernSigns[10] : _westernSigns[9];
                            break;
                        case 11:
                            WesternSign = bday >= 22 ? _westernSigns[11] : _westernSigns[10];
                            break;
                        case 12:
                            WesternSign = bday >= 22 ? _westernSigns[0] : _westernSigns[11];
                            break;

                    }

                }
            }
        }

    }
}
