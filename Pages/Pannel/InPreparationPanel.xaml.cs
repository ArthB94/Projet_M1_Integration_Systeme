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
    /// Logique d'interaction pour InPreparationPanel.xaml
    /// </summary>
    

    public partial class InPreparationPanel : Page
    {
        public MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
        public InPreparationPanel()
        {
            InitializeComponent();
            DgPizzasInPreparation.ItemsSource = mainWindow.PizzaInPreparation;
            DgPizzasReady.ItemsSource = mainWindow.PizzaReady;
        }

        
    }
}
