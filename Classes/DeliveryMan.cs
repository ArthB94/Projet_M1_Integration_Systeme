using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Projet_M1_Integration_Systeme
{
    public class DeliveryMan
    {
        private MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
        private Clerk clerk {  get; set; }
        public ObservableCollection<Commande> CommandesToDeliver = new ObservableCollection<Commande>();
        public ObservableCollection<Commande> CommandeDelivered = new ObservableCollection<Commande>();
        public string Status {  get; set; }
        public DeliveryMan() 
        {
            Status = "Waiting";
            clerk = mainWindow.clerk;
        }


        public void  Deliver(Commande Commande)
        {
            CommandesToDeliver.Add(Commande);
            StartDelivering();

        }
        public async void StartDelivering()
        {
            
            if (Status == "Working")
            {
                return;
            }
            Status = "Working";
            while(CommandesToDeliver.Count() != 0)
            {
                await DeliverCommande(CommandesToDeliver[0]);

            }
            Status = "Waiting";
        }
        public async Task DeliverCommande(Commande commande)
        {
            while (commande.DeliveryDelay > 0)
            {
                await Task.Delay(1000);
                commande.DeliveryDelay -= 1;
            }

            CommandeDelivered.Add(commande);
            CommandesToDeliver.Remove(commande);
            clerk.SendAddition(commande);

        }
    }
}
