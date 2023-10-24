using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;

namespace Projet_M1_Integration_Systeme
{
    public class Kitchen
    {
        public MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
        public DeliveryMan DeliveryMan { get; set; }
        public List<Cook> Cooks { get; set; }
        public ObservableCollection<Command> Commands { get; set; } = new ObservableCollection<Command>();
        public ObservableCollection<Command> CommandsReady { get; set; } = new ObservableCollection<Command>();
        public Kitchen()
        {

            Cooks = new List<Cook> {
                new Cook (this,"Mathieu"),
                new Cook(this, "Jack")
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
        public void addCommand (Command command)
        {
            Commands.Add(command);
            StartPreparation();
        }

        public async void SendCommands(Command command)
        {
            await Task.Delay (5000);
            DeliveryMan.Deliver(command);
            CommandsReady.Remove(command);

        }
    }
}
