using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Projet_M1_Integration_Systeme
{
    public class Pizza : INotifyPropertyChanged
    {
        private string selectedSize;
        private string selectedName;

        public Pizza()
        {
            SelectedName = AvailableName[0];
            SelectedSize = AvailableSizes[0];
        }
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class PizzaViewModel : INotifyPropertyChanged
    {
        public static int count = 0;
        public event PropertyChangedEventHandler PropertyChanged;
        public event Action PriceChanged;
        public int Id { get; }

        public PizzaViewModel(Pizza pizza)
        {
            count++;
            Pizza = pizza;
            Pizza.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == "Price")
                {
                    OnPropertyChanged(nameof(Price));
                    PriceChanged?.Invoke();
                }
            };
            Id = count;
        }


        public Pizza Pizza { get; }

        public string Price => $"${Pizza.Price}";

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            PriceChanged?.Invoke();
        }
    }

}
