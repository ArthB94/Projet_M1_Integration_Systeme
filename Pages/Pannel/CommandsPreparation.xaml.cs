using System.Windows;
using System.Windows.Controls;


namespace Projet_M1_Integration_Systeme.Pages.Pannel
{
    /// <summary>
    /// Logique d'interaction pour CommandPannel.xaml
    /// </summary>
    public partial class CommandPreparation : Page
    {
        public MainWindow mainWindow { get; set; } = (MainWindow)Application.Current.MainWindow;
        public Frame FrameShow { get; set; }
        public CommandPreparation(Frame framefhow)
        {
            FrameShow = framefhow;
            InitializeComponent();
            DgCommandsInPreparation.ItemsSource = mainWindow.kitchen.Commands;
            DgCommandsToDeliver.ItemsSource = DeliveryMan.CommandsToDeliver;
        }
        public void BtnShow_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (button.DataContext is Command command)
                {
                    FrameShow.Navigate(new DetailsCommand(FrameShow, command));
                }
            }
        }
    }
}
