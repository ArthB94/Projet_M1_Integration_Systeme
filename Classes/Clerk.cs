using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Remoting;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Markup;
using Newtonsoft.Json;
using Projet_M1_Integration_Systeme.Pages.Pannel;

namespace Projet_M1_Integration_Systeme.Classes
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
            List<Commande> commandes = LoadCommande();
            lastCommadeID = commandes.Count +1;
            NewCommande();
            commandeShown = currentCommande;
        }
        public void NewCommande()
        {
            
            currentCommande= new Commande(lastCommadeID, new ObservableCollection<PizzaViewModel>());

        }
        public void AddPizza()
        {
            currentCommande.Pizzas.Add(new PizzaViewModel(new Pizza()));
        }
        public void RemovePizza(PizzaViewModel pizza) {
            currentCommande.Pizzas.Remove(pizza);
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
        public List<Commande> LoadCommande ()
        {
            string jsonContent = File.ReadAllText(jsonFileSource + "Commande.json");
            return JsonConvert.DeserializeObject<List<Commande>>(jsonContent);           
        }
        public void SendAddition(Commande commande)
        {
            Console.WriteLine("SendAddition");
            MessageBox.Show("Commande "+commande.ToString() + "delivered");
            SaveCommande( commande);
        }

        public void SaveCommande(Commande NewValue)
        {
            string jsonFilePath = jsonFileSource + "Commande.json";
            string jsonContent = File.ReadAllText(jsonFilePath);
            List<Commande> data = JsonConvert.DeserializeObject<List<Commande>>(jsonContent);
            data.Add(NewValue);
            string updatedJson = JsonConvert.SerializeObject(data, Formatting.Indented);
            Console.WriteLine(updatedJson);
            File.WriteAllText(jsonFilePath, updatedJson);
        }
    }
}
