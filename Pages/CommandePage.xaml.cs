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
        public CommandePage()
        {
            InitializeComponent();

            // permet de mettre à jour le prix total de la commande lorsque chaque pizza est modifiée
            foreach (var pizzaViewModel in mainWindow.Pizzas)
            {
                pizzaViewModel.PriceChanged += UpdateTotalPrice;
            }

            // permet de mettre à jour le prix total de la commande lorsque la page est chargée
            LblTotalPriceValue.Content = TotalPrice;
            DgPizzas.ItemsSource = mainWindow.Pizzas;
        }

        // permet d'ajouter une pizza à la commande 
        public void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Pizzas.Add(new PizzaViewModel(new Pizza()));
            UpdateTotalPrice();

            // permet de mettre à jour le prix total de la commande lorsque chaque nouvelle pizza est modifiée
            foreach (var pizzaViewModel in mainWindow.Pizzas)
            {
                pizzaViewModel.PriceChanged += UpdateTotalPrice;
            }
        }

        // permet de supprimer une pizza de la commande
        public void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (button.DataContext is PizzaViewModel pizzaViewModel)
                {
                    mainWindow.Pizzas.Remove(pizzaViewModel);
                }
            }
            UpdateTotalPrice();
        }

        // permet de mettre à jour le prix total de la commande sur l'affichage
        private void UpdateTotalPrice()
        {
            LblTotalPriceValue.Content = TotalPrice;
        }

        public int TotalPrice => mainWindow.Pizzas.Sum(p => p.Pizza.Price);

        // permet de passer à la page suivante
        public void BtnBuy_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Merci pour votre achat !");
            mainWindow.BtnNext_Click(sender, e);
        }

        // permet de passer à la page précédente
        public void BtnPrevious_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.BtnPrevious_Click(sender, e);
        }



    }
}
