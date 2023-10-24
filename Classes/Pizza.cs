using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;
using Newtonsoft.Json;

namespace Projet_M1_Integration_Systeme
{
    public class Pizza : INotifyPropertyChanged
    {
        public static List<string> AvailableName { get; } = new List<string> { "Margarita", "Pepperoni", "Cheese", "Vegetarian", "Hawaiian", "Meat Lovers", "Seafood" };
        public static List<string> AvailableSizes { get; } = new List<string> { "Small", "Medium", "Large", "Extra Large" };
        public static List<string> AvailableStatus { get; } = new List<string> { "Waiting", "InPreparation", "Prepared" };
        
        
        private string selectedSize;
        private string selectedName;
        
        [JsonIgnore]
        public int Delay { get; set; }
        [JsonIgnore]
        public string Status { get; set; }




        public event Action PriceChanged;
        public Pizza()
        {
            SelectedName = AvailableName[0];
            SelectedSize = AvailableSizes[0];
            Status = AvailableStatus[0];
            Delay = CalculateDelay();
        }
        public Pizza(string Name, string Size ) {
            if (!AvailableName.Contains(Name) ) {
                MessageBox.Show(Name + " not in avaliable names");
                return;
            }
            else if(!AvailableSizes.Contains(Size))
            {
                MessageBox.Show(Size + " not in avaliable sizes");
                return;

            }
            SelectedName = Name;
            SelectedSize = Size;
            Status = AvailableStatus[0];
            Delay = CalculateDelay();
        }



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
                    Delay = CalculateDelay();
                }
            }
        }

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
                    Delay = CalculateDelay();

                }
            }
        }
        public double Price => CalculatePrice();
        public async Task Prepare()
        {
            if (Status == AvailableStatus[1]) return;
            Status = AvailableStatus[1];
            Console.WriteLine($"Prepare");
            while (Delay > 0 && Status != AvailableStatus[2])
            {
                await Task.Delay(1000);
                //Console.WriteLine($"Delay:{ Delay} Status: {Status}");
                Delay -= 1;
                OnPropertyChanged(nameof(Delay));
            }
            Status = AvailableStatus[2];
            return ;
        }


        // Définit le prix de la pizza en fonction de sa taille et de son nom

        private double CalculatePrice()
        {
            var price = 0.0;
            if (SelectedSize == "Small") price += 5;
            else if (SelectedSize == "Medium") price += 10;
            else if (SelectedSize == "Large") price += 15;
            else if (SelectedSize == "Extra Large") price += 20;

            if (new string[] { "Pepperoni", "Vegetarian", "Cheese" }.Contains(SelectedName)) price += 2;
            else if (new string[] { "Hawaiian", "Meat Lovers", "Seafood" }.Contains(SelectedName)) price += 3;

            return price;
        }

        // Définit le temps de préparation de la pizza en fonction de sa taille et de son nom

        private int CalculateDelay()
        {
            var delay = 0;
            if (SelectedSize == "Small") delay += 5;
            else if (SelectedSize == "Medium") delay += 7;
            else if (SelectedSize == "Large") delay += 10;
            else if (SelectedSize == "Extra Large") delay += 13;

            if (new string[] { "Pepperoni", "Meat Lovers",  "Cheese" }.Contains(SelectedName)) delay += 1;
            else if (new string[] { "Hawaiian", "Vegetarian", "Seafood" }.Contains(SelectedName)) delay += 2;
            return delay ;
        }

        // Creer un Evenement qui permet de mettre à jour le prix de la pizza lorsqu'une propriété est modifiée
        public event PropertyChangedEventHandler PropertyChanged;

        // Creer une fonction qui invoque l'evenement de mise à jour du prix de la pizza quand nécessaire
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            PriceChanged?.Invoke();

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
                }
                if (args.PropertyName == "Delay")
                {
                    OnPropertyChanged(nameof(Delay));
                }
            };
        }

        public Pizza Pizza { get; }

        // Définit comment doit etre affiché le nom de la pizza dans la vue
        public string Price => $"${Pizza.Price}";
        public string Delay => $"{Pizza.Delay/60}:{Pizza.Delay % 60}";



        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            PriceChanged?.Invoke();
        }
    }

}
