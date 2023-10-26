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
        public Frame FrameShow { get; set; }
        public DetailsCommand(Frame frameshow,Command command)
        {
            FrameShow = frameshow;
            InitializeComponent();
            DgPizzasInPreparation.ItemsSource =command.Pizzas;
            DgPizzasReady.ItemsSource = command.PizzasReady;
        }
        public void BtnShow_Click(object sender, RoutedEventArgs e)
        {
            FrameShow.Navigate(new CommandsStatusPage());
        }
    }

}
