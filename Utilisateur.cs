using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_M1_Integration_Systeme
{
    public class  Pizza
    {
        
        public string Name { get; set; }
        public string Size { get; set; }
        public int Price() {
            var price = 0;
            if (Size == "Small")
            {
                price += 5;
            }
            else if (Size == "Medium")
            {
                price += 10;
            }
            else if (Size == "Large")
            {
                price += 15;
            }
            else
                return -1;
            if (Name == "Margherita")
            {
                return price;
            }
            else if (Name == "Pepperoni")
            {
                return price + 2;
            }
            else if (Name == "Hawaiian")
            {
                return price + 3;
            }
            else
                return -1;
        }   
    }

    public class PizzaViewModel
    {
        private Pizza _pizza;

        public PizzaViewModel(Pizza pizza)
        {
            _pizza = pizza;
        }

        public string Name => _pizza.Name;
        public string Size => _pizza.Size;
        public string Price => $"Price: {_pizza.Price()}"; // Appel de la méthode Price et conversion en chaîne
    }
}
