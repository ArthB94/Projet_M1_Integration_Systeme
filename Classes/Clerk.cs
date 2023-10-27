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
    public class Clerk : Person
    {
        public MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
        public static List<Clerk> ClerkReady = new List<Clerk> { new Clerk("Arthur"), new Clerk("Asma") };
        public static ObservableCollection<Clerk> ListOfClerks { get; set; } = new ObservableCollection<Clerk> { };
        public string Status { get; set; }
        public Command currentCommand { get; set; }
        public Customer currentCustomer { get; set; }
        private static string jsonFileSource = Directory.GetCurrentDirectory() + "/../../JSONFiles/";
        public int cptCmd { get; set; } = 0;
        public static void cloneList(List<Clerk> listtoclone)
        {
            foreach (Clerk c in listtoclone)
            {
                ListOfClerks.Add(c);
            }

        }
        public Clerk(string name) : base(name)
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

            currentCommand = new Command(new ObservableCollection<PizzaViewModel>(), new ObservableCollection<DrinkViewModel>());
            currentCommand.CustomerName = currentCustomer.Name;
            currentCommand.CustomerSurname = currentCustomer.Surname;
            currentCommand.CustomerId = currentCustomer.Id;
        }
        public void AddPizza()
        {
            currentCommand.Pizzas.Add(new PizzaViewModel(new Pizza()));
        }
        public void AddDrink()
        {
            currentCommand.Drinks.Add(new DrinkViewModel(new Drink()));
        }
        public void RemovePizza(PizzaViewModel pizza)
        {
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
        public static List<CommandReader> LoadCommands()
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
            if (customer.FirstCommandDate == null)
            {
                customer.FirstCommandDate = command.Date_time;
            }
            UpdateCustomer(customer);

            MessageBox.Show("Command " + JsonConvert.SerializeObject(new CommandReader(command), Formatting.Indented) + " delivered");
            StoreCommand(command);
        }

        public static List<Customer> LoadCustomers()
        {
            string jsonContent = File.ReadAllText(jsonFileSource + "Customers.json");
            List<Customer> data = JsonConvert.DeserializeObject<List<Customer>>(jsonContent);
            foreach (Customer customer in data)
            {
                customer.TotalAmount = GetTotalAmountByCustomer(customer.Id);
            }
            return data;
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
                MessageBox.Show("Customer not found for id " + id);
                return null;
            }
        }
        public static void UpdateCustomer(Customer customer)
        {
            List<Customer> data = LoadCustomers();
            Customer foundCustomer = data.Find(c => c.Id == customer.Id);
            if (foundCustomer != null)
            {
                data.Remove(foundCustomer);
                data.Add(customer);
            }
            else
            {
                MessageBox.Show("Customer not found for id " + customer.Id);
            }
            string updatedJson = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(jsonFileSource + "Customers.json", updatedJson);
        }
        public int getMyCommands()
        {
            List<CommandReader> allComds = LoadCommands(); //all commands
            List<CommandReader> mycmd = new List<CommandReader>(); //empty list of only mine
            this.cptCmd = 0;
            foreach (CommandReader cmd in allComds)
            {
                if (cmd.ClerkName == this.Name)
                {
                    OnPropertyChanged(nameof(cptCmd));
                    mycmd.Add(cmd);
                    this.cptCmd++;
                }

            }

            return this.cptCmd;
        }
        public static List<CommandReader> GetCommandsByCustomer(int customerId)
        {
            List<CommandReader> commands = LoadCommands();
            commands = commands.FindAll(command => command.CustomerId == customerId);
            return commands;

        }
        public static double GetTotalAmountByCustomer(int customerId)
        {
            List<CommandReader> commands = GetCommandsByCustomer(customerId);
            double totalAmount = 0;
            foreach (CommandReader command in commands)
            {
                totalAmount += command.Price;
            }
            return totalAmount;
        }
        public static List<CommandReader> orderedAtSpecTime(DateTime? timeBegin, DateTime? timeEnds)
        {
            List<CommandReader> allComds = LoadCommands(); //all commands
            List<CommandReader> inTime = new List<CommandReader>(); //empty list of only right time

            foreach (CommandReader cmd in allComds)
            {
                if (DateTime.Parse(cmd.Date_time) >= timeBegin && DateTime.Parse(cmd.Date_time) <= timeEnds)
                {
                    inTime.Add(cmd);
                }

            }

            return inTime;
        }
        public static double getAvgAccount()
        {
            double ttlAccount = 0;
            List<CommandReader> allComds = LoadCommands(); //all commands
            List<Customer> allClients = LoadCustomers(); //all clients

            foreach (CommandReader cmd in allComds)
            {
                ttlAccount += cmd.Price;
            }
            return ttlAccount / allClients.Count;

        }
        public static List<Customer> ListOfCustomers()
        {
            List<Customer> allClients = LoadCustomers(); //all clients
            return allClients;
        }
        public static List<Customer> OrderedByName(List<Customer> allClients)
        {
            List<Customer> SortedList = allClients.OrderBy(o => o.Name).ToList();
            return SortedList;
        }
    }
}
