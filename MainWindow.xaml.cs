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
    public partial class MainWindow : Window
    {
        public ObservableCollection<PizzaViewModel> Pizzas { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Pizzas = new ObservableCollection<PizzaViewModel>
            {
                new PizzaViewModel(new Pizza ()),
                // Ajoutez autant d'éléments que vous le souhaitez
            };
            // Abonnez-vous à l'événement PriceChanged de chaque PizzaViewModel
            foreach (var pizzaViewModel in Pizzas)
            {
                pizzaViewModel.PriceChanged += UpdateTotalPrice;
            }

            LblTotalPriceValue.Content = TotalPrice;
            DgPizzas.ItemsSource = Pizzas;
        }

        public void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Pizzas.Add(new PizzaViewModel(new Pizza()));
            UpdateTotalPrice();
        }

        public void BtnBuy_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Merci pour votre achat !");
        }

        public void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (button.DataContext is PizzaViewModel pizzaViewModel)
                {
                    Pizzas.Remove(pizzaViewModel);
                }
            }
            UpdateTotalPrice();
        }
        private void UpdateTotalPrice()
        {
            LblTotalPriceValue.Content = TotalPrice;
        }

        public int TotalPrice => Pizzas.Sum(p => p.Pizza.Price);


    }
}
