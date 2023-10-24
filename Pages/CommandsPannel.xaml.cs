
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
        public CommandPannel CommandPannel { get; set; }



        public CommandsPannel()
        {
            CommandPannel CommandPannel = new CommandPannel();

            InitializeComponent();
            FramePizza.Content = CommandPannel;
            DgCommandsDelivered.ItemsSource = mainWindow.deliveryMan.CommandsToDeliver;

        }

        public void ShowCommand()
        {
            InPreparationPanel InPreparationPanel = new InPreparationPanel();
            FramePizza.Content = InPreparationPanel;
        }
        public void ShowCommands() 
        {
            CommandPannel CommandPannel = new CommandPannel();
            FramePizza.Content = CommandPannel;

        }

    }
}
