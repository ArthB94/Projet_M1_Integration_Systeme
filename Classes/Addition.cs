using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_M1_Integration_Systeme.Classes
{
    public class Addition : INotifyPropertyChanged
    {
        private string selectedVolume;
        private string selectedType;
        public List<string> AvailableType { get; } = new List<string> { "Cola", "Orange juice", "Perrier", "Ice Tea", "Orangina", "Lemonade", "Appel juice" };
        public List<string> AvailableVolume { get; } = new List<string> { "25cl", "35cl", "50cl", "1L" };

        public double Price => CalculatePrice();

        public Addition()
        {
            SelectedType = AvailableType[0];
            SelectedVolume = AvailableVolume[0];
        }



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
        }

        // Définit la class AdditionViewModel comme un objet observable. Cette classe permet de définir comment une addition (drinks) doit etre affiché dans la vue
        public class AdditionViewModel : INotifyPropertyChanged
        {
            // Creer un Evenement qui permet de mettre à jour le prix de la boisson lorsque celui ci est modifié
            public event PropertyChangedEventHandler PropertyChanged;

            // Creer un Evenement qui permet de mettre à jour le prix total de la commande lorsque celui ci est modifié
            public event Action PriceChanged;

            public AdditionViewModel(Addition addition)
            {
                Addition = addition;
                Addition.PropertyChanged += (sender, args) =>
                {
                    if (args.PropertyName == "Price")
                    {
                        OnPropertyChanged(nameof(Price));
                    }
                };
            }

            public Addition Addition { get; }

            // Définit comment doit etre affiché le nom de la boisson dans la vue
            public string Price => $"${Addition.Price}";



            protected void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                PriceChanged?.Invoke();
            }
        }
    }
}
