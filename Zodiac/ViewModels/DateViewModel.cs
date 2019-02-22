using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using KMA.ProgrammingInCSharp2019.Practice3.LoginControlMVVM.Properties;
using Zodiac.Models;
using Zodiac.Tools;

namespace Zodiac.ViewModels
{
    internal class DateViewModel : INotifyPropertyChanged
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
            set {
                _user.BirthDate = value;

                if ( _user.Congrats )
                {
                    MessageBox.Show("Happy birthday!!!");

                }
                
                OnPropertyChanged();

            }
        }

        #region Commands

        public RelayCommand<object> FindSignCommand
        {
            get

           {
                return _findSignCommand ?? (_findSignCommand = new RelayCommand<object>(
                           o =>
                           {
                               VisibilityText = "Visible";

                           }, o => CanExecuteCommand()));
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
            
            return !((_birthDate > DateTime.Now) || (Age() > 135));
        }

        private int Age()
        {
            if (_birthDate.Month > DateTime.Now.Month ||(_birthDate.Month == DateTime.Now.Month && _birthDate.Day > DateTime.Now.Day))
            {
                return DateTime.Now.Year - _birthDate.Year - 1;

            }
            else if (_birthDate.Month<DateTime.Now.Month ||(_birthDate.Month == DateTime.Now.Month && _birthDate.Day <= DateTime.Now.Day))
            {
             return  DateTime.Now.Year - _birthDate.Year;
            }

            return 0;
        }

        private void

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }

}
