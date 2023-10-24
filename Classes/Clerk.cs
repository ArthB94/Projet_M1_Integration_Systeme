using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Markup;
using Newtonsoft.Json;


namespace Projet_M1_Integration_Systeme
{
    public class Clerk
    {
        public MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public Command currentCommand {get; set; }
        public Command commandShown { get; set; }
        private string jsonFileSource = Directory.GetCurrentDirectory() + "/../../JSONFiles/";
        private int lastCommadeID;


        public Clerk(int id, string name)
        {
            Id = id;
            Name = name;
            Status = "Waiting";
            List<CommandParser> commands = LoadCommands();
            if (commands.Count() > 0)
            {
                Command.IDS = commands.Last().Id;
            }

            NewCommand();
            commandShown = currentCommand;
        }
        public void NewCommand()
        {
            
            currentCommand= new Command( new ObservableCollection<PizzaViewModel>(), new ObservableCollection<DrinkViewModel>());

        }
        public void AddPizza()
        {
            currentCommand.Pizzas.Add(new PizzaViewModel(new Pizza()));
        }
        public void AddDrink()
        {
            currentCommand.Drinks.Add(new DrinkViewModel(new Drink()));
        }
        public void RemovePizza(PizzaViewModel pizza) {
            currentCommand.Pizzas.Remove(pizza);
        }
        public void RemoveDrink(DrinkViewModel drink)
        {
            currentCommand.Drinks.Remove(drink);
        }

        public void LaunchCurentCommand()
        {
            currentCommand.ClerkName = Name;
            Console.WriteLine("AddCurentCommand");
            mainWindow.kitchen.addCommand(currentCommand);
            lastCommadeID++;
            NewCommand();
            
        }
        public void CommandShown(Command command)
        {
            commandShown = command;
            if (mainWindow.commandsPannel !=null)
            {
                mainWindow.commandsPannel.ShowCommand();
            }
        }
        public void ShowCommands()
        {
            if (mainWindow.commandsPannel != null)
            {
                mainWindow.commandsPannel.ShowCommands();
            }
        }
        public List<CommandParser> LoadCommandsFile(string fileName)
        {
            string jsonContent = File.ReadAllText(fileName);
            List<CommandParser> commands = JsonConvert.DeserializeObject<List<CommandParser>>(jsonContent);
            return commands;
        }
        public List<CommandParser> LoadCommands ()
        {
            return LoadCommandsFile(jsonFileSource + "Commands.json");
        }

        public void LoadCommandFile(string fileName)
        {
            List<CommandParser> commands = LoadCommandsFile(fileName);
            var command = commands.Last();
            foreach (Pizza pizza in command.Pizzas)
            {
                currentCommand.Pizzas.Add(new PizzaViewModel(pizza));
            }
            foreach (Drink drink in command.Drinks)
            {
                currentCommand.Drinks.Add(new DrinkViewModel(drink));
            }

        }
        public List<Client> LoadClients()
        {
            string jsonContent = File.ReadAllText(jsonFileSource + "Client.json");
            return JsonConvert.DeserializeObject<List<Client>>(jsonContent);
        }
        public void SendAddition(Command command)
        {
            Console.WriteLine("SendAddition");
            command.setDate();
            MessageBox.Show("Command "+ JsonConvert.SerializeObject(new CommandParser(command), Formatting.Indented) + " delivered");
            SaveCommand( command);
        }

        public void SaveCommand(Command NewValue)
        {
            string jsonFilePath = jsonFileSource + "Commands.json";
            string jsonContent = File.ReadAllText(jsonFilePath);
            List<CommandParser> data = JsonConvert.DeserializeObject<List<CommandParser>>(jsonContent);
            data.Add(new CommandParser(NewValue));
            string updatedJson = JsonConvert.SerializeObject(data, Formatting.Indented);
            Console.WriteLine(updatedJson);
            File.WriteAllText(jsonFilePath, updatedJson);
        }
    }
}
