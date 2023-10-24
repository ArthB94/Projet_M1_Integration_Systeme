using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Projet_M1_Integration_Systeme
{
    public class DeliveryMan : Person
    {
        private MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
        private Clerk clerk;
        public ObservableCollection<Command> CommandsToDeliver = new ObservableCollection<Command>();
        public ObservableCollection<Command> CommandsDelivered = new ObservableCollection<Command>();
        public string Name { get; set; }
        public string Status {  get; set; }
        public DeliveryMan(string name) : base(name) 
        {
            Name = name;
            Status = "Waiting";
            clerk = mainWindow.clerk;
        }


        public void  Deliver(Command Command)
        {
            CommandsToDeliver.Add(Command);
            StartDelivering();

        }
        public async void StartDelivering()
        {
            
            if (Status == "Working")
            {
                return;
            }
            Status = "Working";
            while(CommandsToDeliver.Count() != 0)
            {
                await DeliverCommande(CommandsToDeliver[0]);

            }
            Status = "Waiting";
        }
        public async Task DeliverCommande(Command command)
        {
            while (command.DeliveryDelay > 0)
            {
                await Task.Delay(1000);
                command.DeliveryDelay -= 1;
            }

            CommandsDelivered.Add(command);
            CommandsToDeliver.Remove(command);
            clerk.SendAddition(command);

        }
    }
}
