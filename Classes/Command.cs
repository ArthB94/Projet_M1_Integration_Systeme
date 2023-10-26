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
        public string CustomerName { get; set; } = "Name";
        public string CustomerSurname { get; set; } = "Surname";
        public int Id { get; set; }
        public string ClerkName { get; set; }

        [JsonIgnore]
        private int delay;

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
    public class CommandReader
    {
        public int Id { get; set; }
        public string ClerkName { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string Status { get; set; }
        [JsonIgnore]
        public string CustomerFullName => CustomerName + " " + CustomerSurname;

        public String Date_time { get; set; }
        public double Price { get; set; }
        public List<Pizza> Pizzas { get; set; } = new List<Pizza>();
        public List<Drink> Drinks { get; set; } = new List<Drink>();

        public CommandReader(Command commande)
        {
            Id = commande.Id;
            Date_time = commande.Date_time;
            Price = commande.Price;
            CustomerName = commande.CustomerName;
            CustomerSurname = commande.CustomerSurname;
            ClerkName = commande.ClerkName;
            Status = commande.Status;

            
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
        public CommandReader(int id, string date_time,string customerName, string customerSurname, string clerkName, double price,string status, List<Pizza> pizzas, List<Drink> drinks)
        {
            Id = id;
            Date_time = date_time;
            Price = price;
            Pizzas = pizzas;
            Drinks = drinks;
            ClerkName = clerkName;
            CustomerName = customerName;
            CustomerSurname = customerSurname;
            Status = status;
        }

        public Command ToCommande()
        {

            Command commande = new Command(new ObservableCollection<PizzaViewModel>(), new ObservableCollection<DrinkViewModel>());
            
            commande.Id = Id;
            commande.Date_time = Date_time;
            commande.CustomerName = CustomerName;
            commande.CustomerSurname = CustomerSurname;
            commande.ClerkName = ClerkName;
            commande.Status = Status;

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
