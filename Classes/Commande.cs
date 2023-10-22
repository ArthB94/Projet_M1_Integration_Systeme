using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_M1_Integration_Systeme.Classes
{
    public class Commande
    {
        public List<Pizza> pizzaList { get; } = new List<Pizza> { };
        public List<Addition> drinksList { get; } = new List<Addition> { };

        public double Price => CalculatePrice();

        public Commande(List<Pizza> pizzaList, List<Addition> drinksList)
        {
            this.pizzaList = pizzaList;
            this.drinksList = drinksList;
        }
    }
}
