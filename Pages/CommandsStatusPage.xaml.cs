
using Projet_M1_Integration_Systeme.Pages.Pannel;
using System.Windows;
using System.Windows.Controls;


namespace Projet_M1_Integration_Systeme.Pages
{
    /// <summary>
    /// Logique d'interaction pour CommandsPannel.xaml
    /// </summary>
    public partial class CommandsStatusPage : Page
    {
        public MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
        public CommandPreparation CommandPannel { get; set; }



        public CommandsStatusPage()
        {
            CommandPreparation CommandPannel = new CommandPreparation();

            InitializeComponent();
            FramePizza.Content = CommandPannel;
            DgCommandsDelivered.ItemsSource = mainWindow.deliveryMan.CommandsToDeliver;

        }

        public void ShowCommand()
        {
            DetailsCommand InPreparationPanel = new DetailsCommand();
            FramePizza.Content = InPreparationPanel;
        }
        public void ShowCommands() 
        {
            CommandPreparation CommandPannel = new CommandPreparation();
            FramePizza.Content = CommandPannel;

        }

    }
}
