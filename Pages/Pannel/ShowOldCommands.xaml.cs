using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projet_M1_Integration_Systeme.Pages.Pannel
{
    /// <summary>
    /// Logique d'interaction pour ShowOldCommands.xaml
    /// </summary>
    public partial class ShowOldCommands : Page
    {
        public Frame FrameShow { get; set; }
        public MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
        public DateTime DateMin { get; set; }
        public DateTime DateMax { get; set; }
        public ShowOldCommands(Frame frameShow)
        {
            DateMin = DateTime.Today;
            DateMax = DateMin.AddDays(7);
            FrameShow = frameShow;
            InitializeComponent();
            SetInitialDates();

            DgHistorique.ItemsSource = Clerk.LoadCommands();
        }
        public void BtnShow_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (button.DataContext is CommandReader command)
                {
                    FrameShow.Navigate(new ShowOldDetails(FrameShow, command));
                }
            }
        }
        public void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            var minDate = DateMinPicker.SelectedDate;
            var maxDate = DateMaxPicker.SelectedDate;

            //MessageBox.Show(minDate.ToString() + " et " + maxDate);
            if (minDate != null && maxDate != null)
            {
                // tu peux changer cette ligne pour faire une recherche dans la base de données
                DgHistorique.ItemsSource = Clerk.orderedAtSpecTime(minDate, maxDate);
            }

        }

        private void DateMinPicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DateMinPicker.SelectedDate >= DateMaxPicker.SelectedDate)
            {
                DateMaxPicker.SelectedDate = DateMinPicker.SelectedDate?.AddDays(1);
            }
        }

        private void DateMaxPicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DateMaxPicker.SelectedDate <= DateMinPicker.SelectedDate)
            {
                DateMinPicker.SelectedDate = DateMaxPicker.SelectedDate?.AddDays(-1);
            }
        }

        private void SetInitialDates()
        {
            DateMinPicker.SelectedDateChanged -= DateMinPicker_SelectedDateChanged;
            DateMaxPicker.SelectedDateChanged -= DateMaxPicker_SelectedDateChanged;

            DateMinPicker.SelectedDate = DateMin;
            DateMaxPicker.SelectedDate = DateMax;

            DateMinPicker.SelectedDateChanged += DateMinPicker_SelectedDateChanged;
            DateMaxPicker.SelectedDateChanged += DateMaxPicker_SelectedDateChanged;
        }
    }

}
