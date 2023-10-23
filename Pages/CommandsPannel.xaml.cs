
using Projet_M1_Integration_Systeme.Pages.Pannel;
using System.Windows;
using System.Windows.Controls;


namespace Projet_M1_Integration_Systeme
{
    /// <summary>
    /// Logique d'interaction pour CommandsPannel.xaml
    /// </summary>
    public partial class CommandsPannel : Page
    {
        public MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
        public CommandePannel CommandePannel { get; set; }



        public CommandsPannel()
        {
            CommandePannel CommandePannel = new CommandePannel();

            InitializeComponent();
            FramePizza.Content = CommandePannel;
            DgCommandesDelivered.ItemsSource = mainWindow.deliveryMan.CommandesToDeliver;

        }

        public void ShowCommande()
        {
            InPreparationPanel InPreparationPanel = new InPreparationPanel();
            FramePizza.Content = InPreparationPanel;
        }
        public void ShowCommandes() 
        {
            CommandePannel CommandePannel = new CommandePannel();
            FramePizza.Content = CommandePannel;

        }

    }
}
