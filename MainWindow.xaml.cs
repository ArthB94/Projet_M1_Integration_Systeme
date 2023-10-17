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

namespace Projet_M1_Integration_Systeme
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<PizzaViewModel> pizzas = new List<PizzaViewModel>
            {
                new PizzaViewModel(new Pizza { Name = "Margherita", Size = "Small" }),
                new PizzaViewModel(new Pizza { Name = "Margherita", Size = "Medium" }),
                new PizzaViewModel(new Pizza { Name = "Margherita", Size = "Large" }),
                new PizzaViewModel(new Pizza { Name = "Pepperoni", Size = "Small" }),
                new PizzaViewModel(new Pizza { Name = "Pepperoni", Size = "Medium" }),
                new PizzaViewModel(new Pizza { Name = "Pepperoni", Size = "Large" }),
                new PizzaViewModel(new Pizza { Name = "Hawaiian", Size = "Small" }),
                new PizzaViewModel(new Pizza { Name = "Hawaiian", Size = "Medium" }),
                new PizzaViewModel(new Pizza { Name = "Hawaiian", Size = "Large" }),

                // Ajoutez autant d'éléments que vous le souhaitez
            };

            LbxPizzas.ItemsSource = pizzas;
        }
    }
}
