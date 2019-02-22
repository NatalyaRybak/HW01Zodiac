using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
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
                OnPropertyChanged();
                OnPropertyChanged(nameof(Age));
                OnPropertyChanged(nameof(ChineseSign));
                OnPropertyChanged(nameof(WesternSign));

                if ( !_user.Executable )
                {
                    MessageBox.Show("Invalid date!!!");
                    VisibilityText = "Hidden";

                } else if ( _user.Congrats )
                {
                    MessageBox.Show("Happy birthday!!!");

                }
                
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
            
            return (_user.Executable);
        }

        public string Age => _user.Age;
        public string ChineseSign => _user.ChineseSign;
        public string WesternSign => _user.WesternSign;



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
