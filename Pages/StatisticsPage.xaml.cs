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
        }

    }

}
