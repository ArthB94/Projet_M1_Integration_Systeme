using System.Windows;
using System.Windows.Controls;
using Projet_M1_Integration_Systeme.Pages.Pannel;

namespace Projet_M1_Integration_Systeme.Pages
{
    /// <summary>
    /// Logique d'interaction pour StatisticsPage.xaml
    /// </summary>
    public partial class StatisticsPage : Page
    {
        public MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;

        public StatisticsPage()
        {
            InitializeComponent();
            FrameShow.Content = new ShowOldCommands(FrameShow);
            BtnShowCustomers.Opacity = 0.5;
            BtnShowCommands.Opacity = 1;
        }
        public void BtnShowCustomers_Click(object sender, RoutedEventArgs e)
        {
            FrameShow.Content = new ShowCustomers(FrameShow);
            BtnShowCustomers.Opacity = 1;
            BtnShowCommands.Opacity = 0.5;
        }
        public void BtnShowCommands_Click(object sender, RoutedEventArgs e)
        {
            FrameShow.Content = new ShowOldCommands(FrameShow);
            BtnShowCustomers.Opacity = 0.5;
            BtnShowCommands.Opacity = 1;
        }

    }


}
