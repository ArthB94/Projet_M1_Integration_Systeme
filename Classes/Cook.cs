using System;
using System.Linq;
using System.Threading.Tasks;

namespace Projet_M1_Integration_Systeme
{
    public class Cook
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        private Kitchen Kitchen { get; set; }

        public Cook(Kitchen kitchen, int id, string name)
        {
            Id = id;
            Name = name;
            Status = "Waiting";
            Kitchen = kitchen;
        }
        public async Task StartPreparation()
        {
            if(Status== "Working")
            {
                Console.WriteLine("Cook" + " Working");
                return;
            }

            Status = "Working";
            
            var commandesFinished = false;
            while (!commandesFinished && Kitchen.Commandes.Count() != 0)
            {
                var IndexCommande = 0;

                while (Kitchen.Commandes[IndexCommande].Status == "Finished")
                {
                    IndexCommande++;

                    if (IndexCommande > Kitchen.Commandes.Count() - 1)
                    {
                        commandesFinished = true;
                        Console.WriteLine("AllcommandesFinished");
                        break;
                    }
                }

                if (!commandesFinished)
                {
                    Commande Commande = Kitchen.Commandes[IndexCommande];
                    Commande.Status = "In Preparation";

                    var commandeFinished = false;
                    while (!commandeFinished && Commande.Pizzas.Count() != 0)
                    {
                        var IndexPizza = 0;
                        while (Commande.Pizzas[IndexPizza].Pizza.Status != "Waiting")
                        {
                            IndexPizza++;
                            if (IndexPizza > Commande.Pizzas.Count() - 1)
                            {
                                Commande.Status = "Finished";
                                commandeFinished = true;
                                break;
                            }
                        }

                        if (!commandeFinished)
                        {
                            PizzaViewModel pizza = Commande.Pizzas[IndexPizza];
                            await pizza.Pizza.Prepare();
                            Commande.PizzasReady.Add(pizza);
                            Commande.Pizzas.Remove(pizza);

                        }
                    }
                    if (Commande.Pizzas.Count() == 0)
                    {
                        Commande.Status = "Ready";
                        Kitchen.CommandesReady.Add(Commande);
                        Kitchen.Commandes.Remove(Commande);
                        Kitchen.SendCommandes(Commande);

                    }
                }
            }
            Console.WriteLine("Cook : " + this.Name + " Finishe Commandes" );

            Status = "Waiting";
        }
    }
    
}
