using System;
using System.Threading.Tasks;
using System.Windows;
using Zodiac.Tools;


namespace Zodiac.ViewModels
{
    internal class DateViewModel : BaseViewModel
    {
        #region Fields
        private DateTime _birthDate = new DateTime(2010,12,3);

        private string _visibilityText = "Hidden";
        private readonly string[] _westernSigns = { "Capricorn", "Aquarius", "Pisces", "Aries", "Taurus", "Gemini", "Cancer", "Leo", "Virgo", "Libra", "Scorpio", "Sagittarius" };
        private readonly string[] _chineseSigns = { "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat", "Monkey", "Rooster", "Dog", "Pig" };
        

        #region Commands
        private RelayCommand<object> _findSignCommand;
        #endregion
        #endregion

        #region Properties
      public DateTime BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; OnPropertyChanged (); }
        }


        #region Commands

        public RelayCommand<object> FindSignCommand
        {
            get

           {
                return _findSignCommand ?? (_findSignCommand = new RelayCommand<object>(DateImplementation));
            }
        }
        #endregion
        #endregion

        public string VisibilityText
        {
            get { return _visibilityText; }
            set
            {
                _visibilityText = value;
                OnPropertyChanged ();
            }
        }

        public bool CanExecuteCommand ()
        {
            return (Executable);
        }

        public string Age { get; private set; }
        public string Date { get; private set; }
        public string ChineseSign { get; private set; }
        public string WesternSign { get; private set; }
        public bool Executable { get; private set; }
        public bool Congrats => DateTime.Today.Month == _birthDate.Month && DateTime.Today.Day == _birthDate.Day;

        private void InitializeProperties()
        {
            Date = _birthDate.ToShortDateString ();
            var age = (DateTime.Today.Year - _birthDate.Year) -
                                      (DateTime.Today.DayOfYear >= _birthDate.DayOfYear ? 0 : 1);
            var diff = DateTime.Today - _birthDate;
            Executable = diff.Days >= 0 && age <= 135;

            if (Executable)
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
            
            VisibilityText = "Hidden";
        }


        private async void DateImplementation(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() =>
            {
                InitializeProperties ();
                VisibilityText = "Visible";
                if (!Executable)
                {
                    VisibilityText = "Hidden";
                    MessageBox.Show("Invalid date!!!");

                }
                else if (Congrats)
                {
                    VisibilityText = "Visible";
                    MessageBox.Show("Happy birthday!!!");
                }

                OnPropertyChanged();
                OnPropertyChanged(nameof(Age));
                OnPropertyChanged(nameof(Date));
                OnPropertyChanged(nameof(ChineseSign));
                OnPropertyChanged(nameof(WesternSign));



            });
            LoaderManager.Instance.HideLoader();
        }

    }

}
