using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_M1_Integration_Systeme.Classes
{
    public class Commande
    {
        public static double totalPrices = 0;
        public static double avg => CalculateAvg();
        public static int IDS = 1;
        public int uniqueID;

        public String date_time= DateTime.Now.ToString("yyyy'-'MM'-'dd'_'HH':'mm':'ss");
        public List<Pizza> pizzaList { get; } = new List<Pizza> { };
        public List<Addition> drinksList { get; } = new List<Addition> { };

        public double Price => CalculatePrice();

        public Commande(List<Pizza> pizzaList, List<Addition> drinksList)
        {
            this.uniqueID = IDS++;
            this.pizzaList = pizzaList;
            this.drinksList = drinksList;
        }

        public double CalculatePrice() //a voir si le price en int dans pizza pose pas pb pcq ici c double
        {
            double price = 0.0;
            foreach(Pizza p in pizzaList) { price += p.Price; }
            foreach(Addition addition in drinksList) {  price += addition.Price; }
            totalPrices += price;
            return price;

        }

        public static double CalculateAvg()
        {
            return totalPrices / (IDS-1);
        }
    }
}
