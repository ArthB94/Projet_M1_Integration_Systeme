﻿using System;
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
            List<CommandReader> commands = LoadCommands();
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
            currentCommand.CustomerName = mainWindow.currentCustomer.Name;
            currentCommand.CustomerSurname = mainWindow.currentCustomer.Surname;
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
            if (mainWindow.CommandsStatusPannel !=null)
            {
                mainWindow.CommandsStatusPannel.ShowCommand();
            }
        }
        public void ShowCommands()
        {
            if (mainWindow.CommandsStatusPannel != null)
            {
                mainWindow.CommandsStatusPannel.ShowCommands();
            }
        }
        public List<CommandReader> LoadCommandsFile(string fileName)
        {
            string jsonContent = File.ReadAllText(fileName);
            List<CommandReader> commands = JsonConvert.DeserializeObject<List<CommandReader>>(jsonContent);
            return commands;
        }
        public List<CommandReader> LoadCommands ()
        {
            return LoadCommandsFile(jsonFileSource + "Commands.json");
        }
        public void StoreCommand(Command newCommand)
        {
            string jsonFilePath = jsonFileSource + "Commands.json";
            string jsonContent = File.ReadAllText(jsonFilePath);
            List<CommandReader> data = JsonConvert.DeserializeObject<List<CommandReader>>(jsonContent);
            data.Add(new CommandReader(newCommand));
            string updatedJson = JsonConvert.SerializeObject(data, Formatting.Indented);
            Console.WriteLine(updatedJson);
            File.WriteAllText(jsonFilePath, updatedJson);
        }

        public void LoadCommandFile(string fileName)
        {
            List<CommandReader> commands = LoadCommandsFile(fileName);
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
        public void SendAddition(Command command)
        {
            Console.WriteLine("SendAddition");
            command.setDate();
            MessageBox.Show("Command " + JsonConvert.SerializeObject(new CommandReader(command), Formatting.Indented) + " delivered");
            StoreCommand(command);
        }

        public List<Customer> LoadCustomers()
        {
            string jsonContent = File.ReadAllText(jsonFileSource + "Customers.json");
            return JsonConvert.DeserializeObject<List<Customer>>(jsonContent);
        }
        public void StoreCustomer(Customer newCustomer)
        {
            string jsonFilePath = jsonFileSource + "Customers.json";
            string jsonContent = File.ReadAllText(jsonFilePath);
            List<Customer> data = JsonConvert.DeserializeObject<List<Customer>>(jsonContent);
            data.Add(newCustomer);
            string updatedJson = JsonConvert.SerializeObject(data, Formatting.Indented);
            Console.WriteLine(updatedJson);
            File.WriteAllText(jsonFilePath, updatedJson);
        }
    }
}
