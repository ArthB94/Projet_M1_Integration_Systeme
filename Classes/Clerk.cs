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
        public Commande currentCommande {get; set; }
        public Commande commandeShown { get; set; }
        private string jsonFileSource = Directory.GetCurrentDirectory() + "/../../JSONFiles/";
        private int lastCommadeID;


        public Clerk(int id, string name)
        {
            Id = id;
            Name = name;
            Status = "Waiting";
            List<CommandeParser> commandes = LoadCommandes();
            Commande.IDS = commandes.Last().Id;
            NewCommande();
            commandeShown = currentCommande;
        }
        public void NewCommande()
        {
            
            currentCommande= new Commande( new ObservableCollection<PizzaViewModel>(), new ObservableCollection<DrinkViewModel>());

        }
        public void AddPizza()
        {
            currentCommande.Pizzas.Add(new PizzaViewModel(new Pizza()));
        }
        public void AddDrink()
        {
            currentCommande.Drinks.Add(new DrinkViewModel(new Drink()));
        }
        public void RemovePizza(PizzaViewModel pizza) {
            currentCommande.Pizzas.Remove(pizza);
        }
        public void RemoveDrink(DrinkViewModel drink)
        {
            currentCommande.Drinks.Remove(drink);
        }

        public void AddCurentCommande()
        {
            Console.WriteLine("AddCurentCommande");
            mainWindow.kitchen.addCommande(currentCommande);
            lastCommadeID++;
            NewCommande();
            
        }
        public void CommandeShown(Commande commande)
        {
            commandeShown = commande;
            if (mainWindow.commandsPannel !=null)
            {
                mainWindow.commandsPannel.ShowCommande();
            }
        }
        public void ShowCommandes()
        {
            if (mainWindow.commandsPannel != null)
            {
                mainWindow.commandsPannel.ShowCommandes();
            }
        }
        public List<CommandeParser> LoadCommandesFile(string fileName)
        {
            string jsonContent = File.ReadAllText(fileName);
            List<CommandeParser> commandes = JsonConvert.DeserializeObject<List<CommandeParser>>(jsonContent);
            return commandes;
        }
        public List<CommandeParser> LoadCommandes ()
        {
            return LoadCommandesFile(jsonFileSource + "Commande.json");
        }

        public void LoadCommandeFile(string fileName)
        {
            List<CommandeParser> commandes = LoadCommandesFile(fileName);
            var commande = commandes.Last();
            foreach (Pizza pizza in commande.Pizzas)
            {
                currentCommande.Pizzas.Add(new PizzaViewModel(pizza));
            }
            foreach (Drink drink in commande.Drinks)
            {
                currentCommande.Drinks.Add(new DrinkViewModel(drink));
            }

        }
        public List<Client> LoadClients()
        {
            string jsonContent = File.ReadAllText(jsonFileSource + "Client.json");
            return JsonConvert.DeserializeObject<List<Client>>(jsonContent);
        }
        public void SendAddition(Commande commande)
        {
            Console.WriteLine("SendAddition");
            commande.setDate();
            MessageBox.Show("Commande "+ JsonConvert.SerializeObject(new CommandeParser(commande), Formatting.Indented) + " delivered");
            SaveCommande( commande);
        }

        public void SaveCommande(Commande NewValue)
        {
            string jsonFilePath = jsonFileSource + "Commande.json";
            string jsonContent = File.ReadAllText(jsonFilePath);
            List<CommandeParser> data = JsonConvert.DeserializeObject<List<CommandeParser>>(jsonContent);
            data.Add(new CommandeParser(NewValue));
            string updatedJson = JsonConvert.SerializeObject(data, Formatting.Indented);
            Console.WriteLine(updatedJson);
            File.WriteAllText(jsonFilePath, updatedJson);
        }
    }
}
