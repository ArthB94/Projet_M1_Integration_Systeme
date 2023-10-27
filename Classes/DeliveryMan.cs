using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Collections.Generic;
using System;
using System.Data.SqlClient;

namespace Projet_M1_Integration_Systeme
{
    public class DeliveryMan : Person
    {
        private MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
        public static List<DeliveryMan> DeliveryMansReady = new List<DeliveryMan> {new DeliveryMan("Jean"),new DeliveryMan("Jack") };
        public static ObservableCollection<Command> CommandsToDeliver = new ObservableCollection<Command>();
        public static ObservableCollection<Command> CommandsDelivering = new ObservableCollection<Command>();
        public static ObservableCollection<DeliveryMan> AllDeliveryMen { get; set; } = new ObservableCollection<DeliveryMan> { };
        public int nbDeliveries { get; set; } = 0;
        public string Status {  get; set; }
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
                command.DeliveryName = Name;
                CommandsDelivering.Remove(command);
                Clerk.SendAddition(command);

                

            }
            DeliveryMansReady.Add(this);
        }
        public static ObservableCollection<DeliveryMan> getAllDeliveryMen()
        {
            return AllDeliveryMen;
        }
        public int getMyCommands()
        {
            List<CommandReader> allComds = Clerk.LoadCommands(); //all commands
            List<CommandReader> mycmd = new List<CommandReader>(); //empty list of only mine
            nbDeliveries = 0;
            foreach (CommandReader cmd in allComds)
            {
                if (cmd.DeliveryName == this.Name)
                {
                    mycmd.Add(cmd);
                    this.nbDeliveries++;
                    OnPropertyChanged(nameof(nbDeliveries));
                   
                }
                if (cmd.DeliveryName == null)
                {
                    cmd.DeliveryName = "null";
                }

            }
            return this.nbDeliveries;
        }
    }
}
