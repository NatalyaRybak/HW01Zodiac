using System;
using System.Threading.Tasks;
using System.Windows;
using Zodiac.Models;
using Zodiac.Tools;


namespace Zodiac.ViewModels
{
    internal class DateViewModel : BaseViewModel
    {
        #region Fields
        private readonly User _user = new User();

        private string _visibilityText = "Hidden";
        

        #region Commands
        private RelayCommand<object> _findSignCommand;
        #endregion
        #endregion

        #region Properties
        public DateTime BirthDate
        {
            get { return _user.BirthDate; }
            set
            {
                _user.BirthDate = value;
                 VisibilityText = "Hidden";
            }
        }
        public string Age => _user.Age;
        public string Date => _user.BirthDate.ToShortDateString ();
        public string ChineseSign => _user.ChineseSign;
        public string WesternSign => _user.WesternSign;
        public bool Executable => _user.Executable;
        public bool Congrats => _user.Congrats;
        
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
        
        private async void DateImplementation(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() =>
            {
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
