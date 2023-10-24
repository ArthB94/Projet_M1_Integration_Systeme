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
        public ShowOldCommands(Frame frameShow)
        {
            FrameShow = frameShow;
            InitializeComponent();
            DgHistorique.ItemsSource = mainWindow.clerk.LoadCommands();
            DateMinPicker.PreviewTextInput += Date_PreviewTextInput;
        }
        public void BtnShow_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (button.DataContext is CommandReader command)
                {
                    FrameShow.Navigate(new ShowOldDetails(FrameShow,command));
                }
            }
        }
        public void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            var minDate = DateMinPicker.SelectedDate;
            var maxDate = DateMaxPicker.SelectedDate;
            MessageBox.Show(minDate.ToString()+" et " + maxDate);
            DgHistorique.ItemsSource = mainWindow.clerk.LoadCommands();
        }

        private void Date_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Regex.IsMatch(e.Text, "^(0[1-9]|1[0-2])/(0[1-9]|[12][0-9]|3[01])/\\d{4}$\r\n"))
            {
                e.Handled = true; // Empêche la saisie du texte non numérique
            }
        }
    }

}
