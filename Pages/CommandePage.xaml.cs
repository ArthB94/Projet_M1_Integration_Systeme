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
        public MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
        public CommandePage()
        {
            InitializeComponent();

            foreach (var pizzaViewModel in mainWindow.Pizzas)
            {
                pizzaViewModel.PriceChanged += UpdateTotalPrice;
            }

            LblTotalPriceValue.Content = TotalPrice;
            DgPizzas.ItemsSource = mainWindow.Pizzas;
        }
        public void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Pizzas.Add(new PizzaViewModel(new Pizza()));
            UpdateTotalPrice();
            foreach (var pizzaViewModel in mainWindow.Pizzas)
            {
                pizzaViewModel.PriceChanged += UpdateTotalPrice;
            }
        }

        public void BtnBuy_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Merci pour votre achat !");
            mainWindow.BtnNext_Click(sender, e);
        }

        public void BtnPrevious_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.BtnPrevious_Click(sender, e);
        }

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
        private void UpdateTotalPrice()
        {
            LblTotalPriceValue.Content = TotalPrice;
        }

        public int TotalPrice => mainWindow.Pizzas.Sum(p => p.Pizza.Price);

    }
}
