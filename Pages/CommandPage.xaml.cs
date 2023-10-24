using System.Linq;
using System.Windows;
using System.Windows.Forms;

namespace Projet_M1_Integration_Systeme.Pages
{
    /// <summary>
    /// Logique d'interaction pour CommandePage.xaml
    /// </summary>
    /// 
    public partial class CommandPage
    {

        // permet de récupérer touts les elements initialisés dans MainWindow
        public MainWindow mainWindow = (MainWindow)System.Windows.Application.Current.MainWindow;
        public double TotalPrice => mainWindow.clerk.currentCommand.Price;

        public CommandPage()
        {
            InitializeComponent();

            // permet de mettre à jour le prix total de la commande lorsque chaque pizza est modifiée
            foreach (var pizza in mainWindow.clerk.currentCommand.Pizzas)
            {
                pizza.PriceChanged += UpdateTotalPrice;
            }
            foreach (var drink in mainWindow.clerk.currentCommand.Drinks)
            {
                drink.PriceChanged += UpdateTotalPrice;
            }

            // permet de mettre à jour le prix total de la commande lorsque la page est chargée
            LblTotalPriceValue.Content = TotalPrice;
            DgPizzas.ItemsSource = mainWindow.clerk.currentCommand.Pizzas;
            DgDrinks.ItemsSource = mainWindow.clerk.currentCommand.Drinks;
        }

        // permet d'ajouter une pizza à la commande 
        public void BtnAddPizza_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.clerk.AddPizza();
            UpdateTotalPrice();

            // permet de mettre à jour le prix total de la commande lorsque chaque nouvelle pizza est modifiée
            foreach (var pizza in mainWindow.clerk.currentCommand.Pizzas)
            {
                pizza.PriceChanged += UpdateTotalPrice;
            }
            foreach (var drink in mainWindow.clerk.currentCommand.Drinks)
            {
                drink.PriceChanged += UpdateTotalPrice;
            }
        }
        public void BtnAddDrink_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.clerk.AddDrink();
            UpdateTotalPrice();
            foreach (var pizza in mainWindow.clerk.currentCommand.Pizzas)
            {
                pizza.PriceChanged += UpdateTotalPrice;
            }
            foreach (var drink in mainWindow.clerk.currentCommand.Drinks)
            {
                drink.PriceChanged += UpdateTotalPrice;
            }
        }

        // permet de supprimer une pizza de la commande
        public void BtnRemovePizza_Click(object sender, RoutedEventArgs e)
        {
            if (sender is System.Windows.Controls.Button button)
            {
                if (button.DataContext is PizzaViewModel pizza)
                {
                    mainWindow.clerk.RemovePizza(pizza);
                }
            }
            UpdateTotalPrice();
        }
        public void BtnRemoveDrink_Click(object sender, RoutedEventArgs e)
        {
            if (sender is System.Windows.Controls.Button button)
            {
                if (button.DataContext is DrinkViewModel addition)
                {
                    mainWindow.clerk.RemoveDrink(addition);
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
            mainWindow.clerk.LaunchCurentCommand();
            DgPizzas.ItemsSource = mainWindow.clerk.currentCommand.Pizzas;
            DgDrinks.ItemsSource = mainWindow.clerk.currentCommand.Drinks;
            //mainWindow.NaviateToPage(0);
        }

        // permet de passer à la page de connection
        public void BtnPrevious_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.NavigateToPage(0);
        }

        public void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Fichiers JSON (*.json)|*.json|Tous les fichiers (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // L'utilisateur a choisi un fichier
                string nomFichier = openFileDialog.FileName;
                mainWindow.clerk.LoadCommandFile(nomFichier);
                DgPizzas.ItemsSource = mainWindow.clerk.currentCommand.Pizzas;
                UpdateTotalPrice();

            }
            foreach (var pizza in mainWindow.clerk.currentCommand.Pizzas)
            {
                pizza.PriceChanged += UpdateTotalPrice;
            }
            foreach (var drink in mainWindow.clerk.currentCommand.Drinks)
            {
                drink.PriceChanged += UpdateTotalPrice;
            }
        }
    }
}
