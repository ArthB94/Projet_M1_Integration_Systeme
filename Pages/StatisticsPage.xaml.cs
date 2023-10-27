using System;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Serialization;
using Projet_M1_Integration_Systeme.Pages.Pannel;

namespace Projet_M1_Integration_Systeme.Pages
{
    /// <summary>
    /// Logique d'interaction pour StatisticsPage.xaml
    /// </summary>
    public partial class StatisticsPage : Page
    {
        public MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
        public UserWindow newWindow = new UserWindow();

        public StatisticsPage()
        {
            Clerk.cloneList(Clerk.ClerkReady);
            DeliveryMan.cloneList(DeliveryMan.DeliveryMansReady);
            InitializeComponent();
            FrameShow.Content = new ShowOldCommands(FrameShow);
            //calc nb of clients beforehand
            foreach (Clerk c in Clerk.ListOfClerks)
            {
                Console.WriteLine(c.getMyCommands() + " give " + c.cptCmd);
            }
            foreach (DeliveryMan d in DeliveryMan.AllDeliveryMen)
            {
                Console.WriteLine(d.getMyCommands() + " deliver " + d.nbDeliveries);
            }
            DgClerks.ItemsSource = Clerk.ListOfClerks;
            DgDeliveryMan.ItemsSource = DeliveryMan.AllDeliveryMen;
            LblAvgCommande.Text = CommandReader.avg.ToString();
            Console.WriteLine("avg tostring " + CommandReader.avg.ToString());
            LblAvgAcount.Text = Clerk.getAvgAccount().ToString();
        }
        public void BtnShowCustomers_Click(object sender, RoutedEventArgs e)
        {
            if (newWindow.IsVisible)
            {
                newWindow.Activate();
            }
            else
            {
                newWindow = new UserWindow();
                newWindow.Show();
            }

        }
       public void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            foreach (Clerk c in Clerk.ListOfClerks)
            {
                Console.WriteLine(c.getMyCommands() + " give " + c.cptCmd);
            }
            foreach (DeliveryMan d in DeliveryMan.AllDeliveryMen)
            {
                Console.WriteLine(d.getMyCommands() + " deliver " + d.nbDeliveries);
            }
            DgClerks.ItemsSource = Clerk.ListOfClerks;
            //DgCustomers.ItemsSource = Clerk.ListOfCustomers();
            DgDeliveryMan.ItemsSource = DeliveryMan.AllDeliveryMen;
            LblAvgCommande.Text = CommandReader.avg.ToString();
            Console.WriteLine("avg tostring " + CommandReader.avg.ToString());
            LblAvgAcount.Text = Clerk.getAvgAccount().ToString();

        }

    }


}
