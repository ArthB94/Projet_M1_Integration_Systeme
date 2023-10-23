using System.Windows;
using System.Windows.Controls;


namespace Projet_M1_Integration_Systeme.Pages.Pannel
{
    /// <summary>
    /// Logique d'interaction pour InPreparationPanel.xaml
    /// </summary>
    

    public partial class InPreparationPanel : Page
    {
        public MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
        public InPreparationPanel()
        {
            InitializeComponent();
            DgPizzasInPreparation.ItemsSource = mainWindow.clerk.commandeShown.Pizzas;
            DgPizzasReady.ItemsSource = mainWindow.clerk.commandeShown.PizzasReady;
        }
        public void BtnShow_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.clerk.ShowCommandes();
        }
    }

}
