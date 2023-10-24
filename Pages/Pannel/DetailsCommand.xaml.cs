using System.Windows;
using System.Windows.Controls;


namespace Projet_M1_Integration_Systeme.Pages.Pannel
{
    /// <summary>
    /// Logique d'interaction pour InPreparationPanel.xaml
    /// </summary>
    

    public partial class DetailsCommand : Page
    {
        public MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
        public DetailsCommand()
        {
            InitializeComponent();
            DgPizzasInPreparation.ItemsSource = mainWindow.clerk.commandShown.Pizzas;
            DgPizzasReady.ItemsSource = mainWindow.clerk.commandShown.PizzasReady;
        }
        public void BtnShow_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.clerk.ShowCommands();
        }
    }

}
