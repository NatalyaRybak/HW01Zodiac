using System;

namespace Zodiac.Models
{
    internal class User
    {
        private DateTime _birthDate;
        private readonly string[] _westernSigns = { "Capricorn", "Aquarius", "Pisces", "Aries", "Taurus", "Gemini", "Cancer", "Leo", "Virgo", "Libra", "Scorpio", "Sagittarius" };
        private readonly string[] _chineseSigns = { "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat", "Monkey", "Rooster", "Dog", "Pig" };
        internal User()
        {
            _birthDate = DateTime.Today;
        }
        public DateTime BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; InitializeProperties ();}
        }
        public string Age { get; private set; }
        public string Date { get; private set; }
        public string ChineseSign { get; private set; }
        public string WesternSign { get; private set; }
        public bool Executable { get; private set; }
        public bool Congrats => DateTime.Today.Month == _birthDate.Month && DateTime.Today.Day == _birthDate.Day;



        private void InitializeProperties()
        {
            Date = _birthDate.ToShortDateString();
            var age = (DateTime.Today.Year - _birthDate.Year) -
                                      (DateTime.Today.DayOfYear >= _birthDate.DayOfYear ? 0 : 1);
            var diff = DateTime.Today - _birthDate;
            Executable = diff.Days > 0 && age <= 135;

            if (Executable)
            {
                Age = age > 0 ? age + " year(s)" : diff.Days + " day(s)";
                ChineseSign = _chineseSigns[(_birthDate.Year + 8) % 12];
                CalcWestSign ();
            }

        }

        private void CalcWestSign ()
        {
            var m = _birthDate.Month;
            var d = _birthDate.Day;
            switch (m)
            {
                case 1:
                    WesternSign = d >= 20 ? _westernSigns[1] : _westernSigns[0];
                    break;
                case 2:
                    WesternSign = d >= 19 ? _westernSigns[2] : _westernSigns[1];
                    break;
                case 3:
                    WesternSign = d >= 21 ? _westernSigns[3] : _westernSigns[2];
                    break;
                case 4:
                    WesternSign = d >= 20 ? _westernSigns[4] : _westernSigns[3];
                    break;
                case 5:
                    WesternSign = d >= 21 ? _westernSigns[5] : _westernSigns[4];
                    break;
                case 6:
                    WesternSign = d >= 21 ? _westernSigns[6] : _westernSigns[5];
                    break;
                case 7:
                    WesternSign = d >= 23 ? _westernSigns[7] : _westernSigns[6];
                    break;
                case 8:
                    WesternSign = d >= 23 ? _westernSigns[8] : _westernSigns[7];
                    break;
                case 9:
                    WesternSign = d >= 23 ? _westernSigns[9] : _westernSigns[8];
                    break;
                case 10:
                    WesternSign = d >= 23 ? _westernSigns[10] : _westernSigns[9];
                    break;
                case 11:
                    WesternSign = d >= 22 ? _westernSigns[11] : _westernSigns[10];
                    break;
                case 12:
                    WesternSign = d >= 22 ? _westernSigns[0] : _westernSigns[11];
                    break;

            }

        }

    }
}
