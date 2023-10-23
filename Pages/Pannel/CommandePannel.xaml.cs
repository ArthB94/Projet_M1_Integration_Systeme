using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projet_M1_Integration_Systeme.Pages.Pannel
{
    /// <summary>
    /// Logique d'interaction pour CommandePannel.xaml
    /// </summary>
    public partial class CommandePannel : Page
    {
        public MainWindow mainWindow { get; set; } = (MainWindow)Application.Current.MainWindow;
        public CommandePannel()
        {
            InitializeComponent();
            DgCommandesInPreparation.ItemsSource = mainWindow.kitchen.Commandes;
            DgCommandesReady.ItemsSource = mainWindow.kitchen.CommandesReady;
        }
        public void BtnShow_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (button.DataContext is Classes.Commande commande)
                {
                    mainWindow.clerk.CommandeShown(commande);
                }
            }
        }
    }
}
