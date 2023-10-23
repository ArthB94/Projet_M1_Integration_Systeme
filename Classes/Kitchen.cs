using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Projet_M1_Integration_Systeme.Classes
{
    public class Kitchen
    {
        public MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
        public DeliveryMan DeliveryMan { get; set; }
        public List<Cook> Cooks { get; set; }
        public ObservableCollection<Commande> Commandes { get; set; } = new ObservableCollection<Commande>();
        public ObservableCollection<Commande> CommandesReady { get; set; } = new ObservableCollection<Commande>();
        public Kitchen()
        {

            Cooks = new List<Cook> {
                new Cook (this,1,"Jean"),
                new Cook(this,2, "Jack")
            };
            DeliveryMan = mainWindow.deliveryMan;

        }

        public async Task StartPreparation()
        {
            List<Task> tasks = new List<Task> ();
               
            foreach (var cook in Cooks)
            {
                if(cook.Status == "Waiting")
                {
                    tasks.Add(cook.StartPreparation());
                }
                
            }
            Console.WriteLine("StartPreparation");
            await Task.WhenAll (tasks);
        }
        public void addCommande (Commande commande)
        {
            Commandes.Add(commande);
            StartPreparation();
        }

        public async void SendCommandes(Commande commande)
        {
            await Task.Delay (5000);
            DeliveryMan.Deliver(commande);
            CommandesReady.Remove(commande);

        }
    }
}
