using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Windows;
using Newtonsoft.Json;

namespace Projet_M1_Integration_Systeme
{
    public class Drink : INotifyPropertyChanged
    {
        public static List<string> AvailableType { get; } = new List<string> { "Cola", "Orange juice", "Perrier", "Ice Tea", "Orangina", "Lemonade", "Appel juice" };
        public static List<string> AvailableVolume { get; } = new List<string> { "25cl", "35cl", "50cl", "1L" };

        [JsonIgnore]
        private string selectedVolume;

        [JsonIgnore]
        private string selectedType;

        public double Price => CalculatePrice();

        public event Action PriceChanged;
        public Drink()
        {
            SelectedType = AvailableType[0];
            SelectedVolume = AvailableVolume[0];
        }
        public Drink(string Type, string Volume)
        {
            if (!AvailableType.Contains(Type))
            {
                MessageBox.Show(Type + " not in avaliable types");
                return;
            }
            else if(!AvailableVolume.Contains(Volume))
            {
                MessageBox.Show(Volume + " not in avaliable volume");
                return;
            }
            SelectedType = Type;
            SelectedVolume = Volume;

        }

        [JsonProperty("Type")]
        public string SelectedType
        {
            get
            {
                return selectedType;
            }
            set
            {

                if (selectedType != value)
                {
                    selectedType = value;
                    OnPropertyChanged(nameof(selectedType));
                    OnPropertyChanged(nameof(Price)); // Informez la vue du changement de prix
                }
            }
        }

        [JsonProperty("Volume")]
        public string SelectedVolume
        {
            get { return selectedVolume; }
            set
            {
                if (selectedVolume != value)
                {
                    selectedVolume = value;
                    OnPropertyChanged(nameof(selectedVolume));
                    OnPropertyChanged(nameof(Price)); // Informez la vue du changement de prix

                }
            }
        }

        private double CalculatePrice()
        {
            var price = 0.0;
            if (selectedVolume == "25cl") price += 0.5;
            else if (selectedVolume == "35cl") price += 0.7;
            else if (selectedVolume == "50cl") price += 1.0;
            else if (selectedVolume == "1L") price += 1.2;

            if (new string[] { "Orange juice", "Perrier", "Appel juice" }.Contains(SelectedType)) price += 0.5;
            else if (new string[] { "Cola", "Orangina", "Ice Tea", "Lemonade" }.Contains(SelectedType)) price += 1;

            return price;
        }

        //Pour gerer le changement de prix
        public event PropertyChangedEventHandler PropertyChanged;

        //invoque l'event de mise a jour du prix
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            PriceChanged?.Invoke();
        }
    }
    // Définit la class DrinkViewModel comme un objet observable. Cette classe permet de définir comment une Drink (drinks) doit etre affiché dans la vue
    public class DrinkViewModel : INotifyPropertyChanged
    {
        // Creer un Evenement qui permet de mettre à jour le prix de la boisson lorsque celui ci est modifié
        public event PropertyChangedEventHandler PropertyChanged;

        // Creer un Evenement qui permet de mettre à jour le prix total de la commande lorsque celui ci est modifié
        public event Action PriceChanged;

        public DrinkViewModel(Drink drink)
        {
            Drink = drink;
            Drink.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == "Price")
                {
                    OnPropertyChanged(nameof(Price));
                }
            };
        }

        public Drink Drink { get; }

        // Définit comment doit etre affiché le nom de la boisson dans la vue
        [JsonIgnore]
        public string Price => $"${Drink.Price}";



        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            PriceChanged?.Invoke();
        }
    }
}