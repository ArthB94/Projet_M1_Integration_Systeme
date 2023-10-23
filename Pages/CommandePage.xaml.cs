using Projet_M1_Integration_Systeme.Pages.Pannel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Logique d'interaction pour CommandePage.xaml
    /// </summary>
    /// 
    public partial class CommandePage : Page
    {

        // permet de récupérer touts les elements initialisés dans MainWindow
        public MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
        public int TotalPrice => mainWindow.clerk.currentCommande.Pizzas.Sum(p => p.Pizza.Price);

        public CommandePage()
        {
            InitializeComponent();

            // permet de mettre à jour le prix total de la commande lorsque chaque pizza est modifiée
            foreach (var pizza in mainWindow.clerk.currentCommande.Pizzas)
            {
                pizza.PriceChanged += UpdateTotalPrice;
            }

            // permet de mettre à jour le prix total de la commande lorsque la page est chargée
            LblTotalPriceValue.Content = TotalPrice;
            DgPizzas.ItemsSource = mainWindow.clerk.currentCommande.Pizzas;
        }

        // permet d'ajouter une pizza à la commande 
        public void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.clerk.AddPizza();
            UpdateTotalPrice();

            // permet de mettre à jour le prix total de la commande lorsque chaque nouvelle pizza est modifiée
            foreach (var pizza in mainWindow.clerk.currentCommande.Pizzas)
            {
                pizza.PriceChanged += UpdateTotalPrice;
            }
        }

        // permet de supprimer une pizza de la commande
        public void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (button.DataContext is PizzaViewModel pizza)
                {
                    mainWindow.clerk.RemovePizza(pizza);
                }
            }
            UpdateTotalPrice();
        }

        // permet de mettre à jour le prix total de la commande sur l'affichage
        private void UpdateTotalPrice()
        {
            LblTotalPriceValue.Content = TotalPrice;
        }

        // permet de passer à la page suivante
        public void BtnBuy_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.clerk.AddCurentCommande();
            DgPizzas.ItemsSource = mainWindow.clerk.currentCommande.Pizzas;
            //mainWindow.NaviateToPage(0);
        }

        // permet de passer à la page de connection
        public void BtnPrevious_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.NaviateToPage(0);
        }
    }
}
