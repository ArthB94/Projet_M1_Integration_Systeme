using System;
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
        Window newWindow = new UserWindow();

        public StatisticsPage()
        {
            InitializeComponent();
            FrameShow.Content = new ShowOldCommands(FrameShow);
            //DgClerks.ItemsSource = une liste
            //DgCustomers.ItemsSource = une liste
            //LblAvgCommande.Text = UnloadedEvent valeur
            //LblAvgCAcount.Text = UnloadedEvent valeur
        }
        public void BtnShowCustomers_Click(object sender, RoutedEventArgs e)
        {

            // affiche la fenetre newWindow et fait en sorte qu'elle ne puisse pas etre dupliquée

            if (newWindow.IsVisible)
            {
                newWindow.Activate();
            }
            else
            {
                newWindow = new UserWindow();
                newWindow.Show();
            }

        }


    }


}
