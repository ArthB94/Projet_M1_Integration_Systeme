using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Collections.Generic;
using System;

namespace Projet_M1_Integration_Systeme
{
    public class DeliveryMan : Person
    {
        private MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
        public static List<DeliveryMan> DeliveryMansReady = new List<DeliveryMan> { new DeliveryMan("Jean"), new DeliveryMan("Jack") };
        public static ObservableCollection<Command> CommandsToDeliver = new ObservableCollection<Command>();
        public static ObservableCollection<Command> CommandsDelivering = new ObservableCollection<Command>();
        public ObservableCollection<Command> CommandsDelivered = new ObservableCollection<Command>();
        public static List<DeliveryMan> AllDeliveryMen { get; set; } = new List<DeliveryMan> { };
        public string Status {  get; set; }
        public int nbDeliveries { get; set; } = 0;

        public static void cloneList(List<DeliveryMan> listtoclone)
        {
            foreach (DeliveryMan c in listtoclone)
            {
                AllDeliveryMen.Add(c);
            }

        }
        public DeliveryMan(string name) : base(name)
        {
            Name = name;
            Status = "Waiting";
            
        }


        public static async void  Deliver(Command Command)
        {
            CommandsToDeliver.Add(Command);
            Command.Status = "Waiting for delivery";
            await Task.Delay(1000);
            StartDelivering();

        }
        public static void StartDelivering()
        {
            //melanger aléatoirement la liste des deliverymanready
            while (CommandsToDeliver.Count > 0 && DeliveryMansReady.Count > 0)
            {
                Random random = new Random();
                int index = random.Next(DeliveryMansReady.Count);
                DeliveryMan deliveryMan = DeliveryMansReady[index];
                deliveryMan.DeliverCommande();

            }

        }
        public async Task DeliverCommande()
        {
            DeliveryMansReady.Remove(this);
            while (CommandsToDeliver.Count > 0)
            {
                Command command = CommandsToDeliver.First();
                bool isLoss = false;
                CommandsToDeliver.Remove(command);
                CommandsDelivering.Add(command);
                command.Status = "Delivering";
                if (command.DeliveryDelay > 8)
                {
                    isLoss = true;
                }
                while (command.DeliveryDelay > 0)
                {
                    await Task.Delay(1000);
                    command.DeliveryDelay -= 1;
                }

                if (isLoss)
                {
                    command.Status = "Loss";
                }
                else
                {
                    command.Status = "Cashed";
                }
                CommandsDelivering.Remove(command);
                Clerk.SendAddition(command);
                this.CommandsDelivered.Add(command);

                

            }
            DeliveryMansReady.Add(this);
        }

        public int getNbOfDelivery()
        {
            this.nbDeliveries = this.CommandsDelivered.Count();
            return this.nbDeliveries;
        }

        public static List<DeliveryMan> getAllDeliveryMen()
        {
            return AllDeliveryMen;
        }
    }
}
