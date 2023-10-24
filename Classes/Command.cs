using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Projet_M1_Integration_Systeme
{
    public class Command : INotifyPropertyChanged
    {
        public static double totalPrices = 0;
        public static double avg => CalculateAvg();
        public static int IDS { get; set; } = 0;

        public String Date_time = DateTime.Now.ToString("yyyy'-'MM'-'dd'_'HH':'mm':'ss");

        public int Id { get; set; }
        public string ClerkName { get; set; }

        [JsonIgnore]
        private int delay;
        [JsonIgnore]
        private string status;

        public ObservableCollection<PizzaViewModel> Pizzas { get; set; }

        public ObservableCollection<DrinkViewModel> Drinks { get; set; }

        [JsonIgnore]
        public ObservableCollection<PizzaViewModel> PizzasReady { get; set; } = new ObservableCollection<PizzaViewModel>();

        public double Price => CalculatePrice();
        public Command(ObservableCollection<PizzaViewModel> pizzas, ObservableCollection<DrinkViewModel> drinklist)
        {
            IDS++;
            Id = IDS;
            Status = "Waiting";
            Pizzas = pizzas;
            Drinks = drinklist;
            delay = 5;

        }
        public string Status 
        { 
            get {return status; }
            set
            {
                status = value;
                OnPropertyChanged(nameof(Status));
            }   
        }
        public int DeliveryDelay
        {
            get { return delay; }
            set
            {
                delay = value;
                OnPropertyChanged(nameof(DeliveryDelay));
            }
        }
        public double CalculatePrice() //a voir si le price en int dans pizza pose pas pb pcq ici c double
        {
            double price = 0.0;
            foreach (PizzaViewModel p in Pizzas) { price += p.Pizza.Price; }
            foreach (PizzaViewModel p in PizzasReady) { price += p.Pizza.Price; }
            foreach (DrinkViewModel d in Drinks) { price += d.Drink.Price; }
            totalPrices += price;
            return price;

        }
        public static double CalculateAvg()
        {
            return totalPrices / (IDS - 1);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void setDate()
        {
            Date_time = DateTime.Now.ToString("yyyy'-'MM'-'dd'_'HH':'mm':'ss");
        }


    }
    public class CommandParser
    {
        public int Id { get; set; }
        public string ClerkName { get; set; }
        public String Date_time { get; set; }
        public double Price { get; set; }
        public List<Pizza> Pizzas { get; set; } = new List<Pizza>();
        public List<Drink> Drinks { get; set; } = new List<Drink>();

        public CommandParser(Command commande)
        {
            Id = commande.Id;
            Date_time = commande.Date_time;
            Price = commande.Price;
            ClerkName = commande.ClerkName;
            
            foreach (PizzaViewModel pizza in commande.PizzasReady)
            {
                Pizzas.Add(pizza.Pizza);
            }
            foreach (DrinkViewModel drink in commande.Drinks)
            {
                Drinks.Add(drink.Drink);
            }
        }

        [JsonConstructor]
        public CommandParser(int id, string date_time,string clerkName, double price, List<Pizza> pizzas, List<Drink> drinks)
        {
            Id = id;
            Date_time = date_time;
            Price = price;
            Pizzas = pizzas;
            Drinks = drinks;
            ClerkName = clerkName;
        }

        public Command ToCommande()
        {

            Command commande = new Command(new ObservableCollection<PizzaViewModel>(), new ObservableCollection<DrinkViewModel>());
            commande.Date_time = Date_time;
            commande.ClerkName = ClerkName;
            foreach (Pizza pizza in Pizzas)
            {
                commande.Pizzas.Add(new PizzaViewModel(pizza));
            }
            foreach (Drink drink in Drinks)
            {
                commande.Drinks.Add(new DrinkViewModel(drink));
            }
            return commande;



        }
    }
}
