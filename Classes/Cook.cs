using System;
using System.Linq;
using System.Threading.Tasks;

namespace Projet_M1_Integration_Systeme
{
    public class Cook : Person
    {

        public string Status { get; set; }
        private Kitchen Kitchen { get; set; }

        public Cook(Kitchen kitchen, string name) : base(name)
        {
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
            
            var commandsFinishing = false;
            while (!commandsFinishing && Kitchen.Commands.Count() != 0)
            {
                var IndexCommand = 0;

                while (Kitchen.Commands[IndexCommand].Status == "Finishing")
                {
                    IndexCommand++;

                    if (IndexCommand > Kitchen.Commands.Count() - 1)
                    {
                        commandsFinishing = true;
                        Console.WriteLine("AllcommandsFinishing");
                        break;
                    }
                }

                if (!commandsFinishing)
                {
                    Command Command = Kitchen.Commands[IndexCommand];
                    Command.Status = "In Preparation";

                    var commandFinishing = false;
                    while (!commandFinishing && Command.Pizzas.Count() != 0)
                    {
                        var IndexPizza = 0;
                        while (Command.Pizzas[IndexPizza].Pizza.Status != "Waiting")
                        {
                            IndexPizza++;
                            if (IndexPizza > Command.Pizzas.Count() - 1)
                            {
                                Command.Status = "Finishing";
                                commandFinishing = true;
                                break;
                            }
                        }

                        if (!commandFinishing)
                        {
                            PizzaViewModel pizza = Command.Pizzas[IndexPizza];
                            await pizza.Pizza.Prepare();
                            Command.PizzasReady.Add(pizza);
                            Command.Pizzas.Remove(pizza);

                        }
                    }
                    if (Command.Pizzas.Count() == 0)
                    {
                        Command.Status = "Ready";
                        Kitchen.CommandsReady.Add(Command);
                        Kitchen.Commands.Remove(Command);
                        Kitchen.SendCommands(Command);

                    }
                }
            }
            Console.WriteLine("Cook : " + this.Name + " Finishe Commands" );

            Status = "Waiting";
        }
    }
    
}
