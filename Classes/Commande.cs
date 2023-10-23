using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Diagnostics;

namespace Projet_M1_Integration_Systeme.Classes
{
    public class Commande : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Status { get; set; }

        private int delay;

        public ObservableCollection<PizzaViewModel> Pizzas { get; set; }
        public ObservableCollection<PizzaViewModel> PizzasReady { get; set; } = new ObservableCollection<PizzaViewModel> ();
        public Commande(int id, ObservableCollection<PizzaViewModel> pizzas)
        {
            Id = id;
            Status = "Waiting";
            Pizzas = pizzas;
            delay = 5;
            
        }
        public int DeliveryDelay { 
            get { return delay; } 
            set { 
                delay = value;
                OnPropertyChanged(nameof(DeliveryDelay));
            } 
        }

        // Creer un Evenement qui permet de mettre à jour le prix de la pizza lorsqu'une propriété est modifiée
        public event PropertyChangedEventHandler PropertyChanged;

        // Creer une fonction qui invoque l'evenement de mise à jour du prix de la pizza quand nécessaire
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        // Creer un tostring pour Commande:
    }  
}
