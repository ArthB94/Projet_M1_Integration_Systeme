using System.Linq;
using System.Windows;
using System.Windows.Controls;
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
        public double TotalPrice => Clerk.currentCommand.Price;
        public Clerk Clerk { get; set;}
        public Frame FrameShow { get; set; }

        public CommandPage(Frame frameshow, Clerk clerk)
        {
            this.Clerk  = clerk;
            FrameShow = frameshow;
            Clerk.NewCommand();
            InitializeComponent();

            // permet de mettre à jour le prix total de la commande lorsque chaque pizza est modifiée
            foreach (var pizza in Clerk.currentCommand.Pizzas)
            {
                pizza.PriceChanged += UpdateTotalPrice;
            }
            foreach (var drink in Clerk.currentCommand.Drinks)
            {
                drink.PriceChanged += UpdateTotalPrice;
            }

            // permet de mettre à jour le prix total de la commande lorsque la page est chargée
            LblTotalPriceValue.Content = TotalPrice;
            DgPizzas.ItemsSource = Clerk.currentCommand.Pizzas;
            DgDrinks.ItemsSource = Clerk.currentCommand.Drinks;
        }

        // permet d'ajouter une pizza à la commande 
        public void BtnAddPizza_Click(object sender, RoutedEventArgs e)
        {
            Clerk.AddPizza();
            UpdateTotalPrice();

            // permet de mettre à jour le prix total de la commande lorsque chaque nouvelle pizza est modifiée
            foreach (var pizza in Clerk.currentCommand.Pizzas)
            {
                pizza.PriceChanged += UpdateTotalPrice;
            }
            foreach (var drink in Clerk.currentCommand.Drinks)
            {
                drink.PriceChanged += UpdateTotalPrice;
            }
        }
        public void BtnAddDrink_Click(object sender, RoutedEventArgs e)
        {
            Clerk.AddDrink();
            UpdateTotalPrice();
            foreach (var pizza in Clerk.currentCommand.Pizzas)
            {
                pizza.PriceChanged += UpdateTotalPrice;
            }
            foreach (var drink in Clerk.currentCommand.Drinks)
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
                    Clerk.RemovePizza(pizza);
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
                    Clerk.RemoveDrink(addition);
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
            Clerk.LaunchCurentCommand();
            DgPizzas.ItemsSource = Clerk.currentCommand.Pizzas;
            DgDrinks.ItemsSource = Clerk.currentCommand.Drinks;

        }

        // permet de passer à la page de connection
        public void BtnPrevious_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.NavigateToPage(0);
            Clerk.CloseCall(Clerk);
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
                Clerk.LoadCommandFile(nomFichier);
                DgPizzas.ItemsSource = Clerk.currentCommand.Pizzas;
                UpdateTotalPrice();

            }
            foreach (var pizza in Clerk.currentCommand.Pizzas)
            {
                pizza.PriceChanged += UpdateTotalPrice;
            }
            foreach (var drink in Clerk.currentCommand.Drinks)
            {
                drink.PriceChanged += UpdateTotalPrice;
            }
        }
    }
}
