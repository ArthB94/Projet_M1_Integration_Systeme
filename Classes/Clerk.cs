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
    public class Clerk : Person
    {
        public MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
        public static List<Clerk> ClerkReady = new List<Clerk> {new Clerk("Arthur"),new Clerk("Asma") };
        public string Status { get; set; }
        public Command currentCommand {get; set; }
        public Customer currentCustomer { get; set; } 
        private static string jsonFileSource = Directory.GetCurrentDirectory() + "/../../JSONFiles/";


        public Clerk( string name) : base(name)
        {

            Name = name;
            Status = "Waiting";
 
        }
        public static Clerk CallPizzaria()
        {
            // retourner un clerk aléatoir dans clerkready et le retirer de la liste
            Random random = new Random();
            int index = random.Next(ClerkReady.Count);
            Clerk clerk = ClerkReady[index];
            ClerkReady.RemoveAt(index);
            return clerk;

        }
        public static void CloseCall(Clerk clerk)
        {
            ClerkReady.Add(clerk);
        }
        public void NewCommand()
        {

            currentCommand= new Command( new ObservableCollection<PizzaViewModel>(), new ObservableCollection<DrinkViewModel>());
            currentCommand.CustomerName = currentCustomer.Name;
            currentCommand.CustomerSurname = currentCustomer.Surname;
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
            NewCommand();
            
        }
        public static List<CommandReader> LoadCommandsFile(string fileName)
        {
            string jsonContent = File.ReadAllText(fileName);
            List<CommandReader> commands = JsonConvert.DeserializeObject<List<CommandReader>>(jsonContent);
            return commands;
        }
        public static List<CommandReader> LoadCommands ()
        {
            return LoadCommandsFile(jsonFileSource + "Commands.json");
        }
        public static void StoreCommand(Command newCommand)
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
        public static void SendAddition(Command command)
        {
            Console.WriteLine("SendAddition");
            command.setDate();
            Customer customer = FindCustomerById(command.CustomerId);

            if (customer.FirstCommandDate == "0001-01-01_00:00:00")
            {
                customer.FirstCommandDate = command.Date_time;
            }
            MessageBox.Show("Command " + JsonConvert.SerializeObject(new CommandReader(command), Formatting.Indented) + " delivered");
            StoreCommand(command);
        }

        public static List<Customer> LoadCustomers()
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
            currentCustomer = newCustomer;
        }
        public bool ConnectCustomer(string phonenumber)
        {
            List<Customer> customers = LoadCustomers();
            Customer foundCustomer = customers.Find(customer => customer.PhoneNumber == phonenumber);
            if (foundCustomer != null)
            {
                currentCustomer = foundCustomer;
                return true;
            }
            else
            {
                Console.WriteLine("Client non enregistré dans la base de données");
                return false;
            }
        }
        public static Customer FindCustomerById(int id)
        {
            List<Customer> customers = LoadCustomers();
            Customer foundCustomer = customers.Find(customer => customer.Id == id);
            if (foundCustomer != null)
            {
                return foundCustomer;
            }
            else
            {
                Console.WriteLine("Client non enregistré dans la base de données");
                return null;
            }
        }
        public static void UpdateCustomer(Customer customer)
        {
            List<Customer> data = LoadCustomers();
            Customer foundCustomer = data.Find(c => c.Id == customer.Id);
            if (foundCustomer != null)
            {
                foundCustomer = customer;
            }
            string updatedJson = JsonConvert.SerializeObject(data, Formatting.Indented);
            Console.WriteLine(updatedJson);
            File.WriteAllText(jsonFileSource + "Customers.json", updatedJson);
        }
    }
}
