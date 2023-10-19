using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Projet_M1_Integration_Systeme
{
    // Définit la class Pizza comme un objet observable, c'est a dire que si un de ses attributs est modifié, la vue est informée
    public class Pizza : INotifyPropertyChanged
    {
        // Définit les caractéristiques d'une pizza qui peuvent etre selectionné parmis une liste.
        private string selectedSize;
        private string selectedName;

        public Pizza()
        {
            SelectedName = AvailableName[0];
            SelectedSize = AvailableSizes[0];
        }

        // Définit la liste des noms de pizza disponible
        public List<string> AvailableName { get; } = new List<string> { "Margarita", "Pepperoni", "Cheese", "Vegetarian", "Hawaiian", "Meat Lovers", "Seafood"};

        public string SelectedName
        {
            get
            {
                return selectedName;
            }
            set
            {
             
                if (selectedName != value)
                {
                    selectedName = value;
                    OnPropertyChanged(nameof(SelectedName));
                    OnPropertyChanged(nameof(Price)); // Informez la vue du changement de prix
                }
            }
        }

        // Définit la liste des tailles de pizza disponible
        public List<string> AvailableSizes { get; } = new List<string> { "Small", "Medium", "Large", "Extra Large" };

        public string SelectedSize
        {
            get { return selectedSize; }
            set
            {
                if (selectedSize != value)
                {
                    selectedSize = value;
                    OnPropertyChanged(nameof(SelectedSize));
                    OnPropertyChanged(nameof(Price)); // Informez la vue du changement de prix
                    
                }
            }
        }


        // Définit le prix de la pizza en fonction de sa taille et de son nom
        public int Price => CalculatePrice();

        private int CalculatePrice()
        {
            var price = 0;
            if (SelectedSize == "Small") price += 5;
            else if (SelectedSize == "Medium") price += 10;
            else if (SelectedSize == "Large") price += 15;
            else if (SelectedSize == "Extra Large") price += 20;

            if (new string[] { "Pepperoni", "Vegetarian", "Cheese" }.Contains(SelectedName)) price += 2;
            else if (new string[] { "Hawaiian", "Meat Lovers", "Seafood" }.Contains(SelectedName)) price += 3;

            return price;
        }

        // Creer un Evenement qui permet de mettre à jour le prix de la pizza lorsqu'une propriété est modifiée
        public event PropertyChangedEventHandler PropertyChanged;

        // Creer une fonction qui invoque l'evenement de mise à jour du prix de la pizza quand nécessaire
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    // Définit la class PizzaViewModel comme un objet observable. Cette classe permet de définir comment une pizza doit etre affiché dans la vue
    public class PizzaViewModel : INotifyPropertyChanged
    {
        // Creer un Evenement qui permet de mettre à jour le prix de la pizza lorsque celui ci est modifié
        public event PropertyChangedEventHandler PropertyChanged;
        
        // Creer un Evenement qui permet de mettre à jour le prix total de la commande lorsque celui ci est modifié
        public event Action PriceChanged;

        public PizzaViewModel(Pizza pizza)
        {
            Pizza = pizza;
            Pizza.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == "Price")
                {
                    OnPropertyChanged(nameof(Price));
                    PriceChanged?.Invoke();
                }
            };
        }

        public Pizza Pizza { get; }

        // Définit comment doit etre affiché le nom de la pizza dans la vue
        public string Price => $"${Pizza.Price}";


        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            PriceChanged?.Invoke();
        }
    }

}
