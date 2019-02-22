using System.Windows.Controls;
using Zodiac.ViewModels;

namespace Zodiac.Views
{
    /// <summary>
    /// Interaction logic for DateControl.xaml
    /// </summary>
    public partial class DateControl : UserControl
    {
        public DateControl()
        {
            InitializeComponent();
            DataContext = new DateViewModel();

        }
    }
}
