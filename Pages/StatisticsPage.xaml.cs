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

        public StatisticsPage()
        {
            //Clerk.tiersFunctionCreateClerk("Arthur");
            //Clerk.tiersFunctionCreateClerk("Asma");
            //DeliveryMan.tiersFunctionCreateDelMan("Jean");
            //DeliveryMan.tiersFunctionCreateDelMan("Jack");
            Clerk.cloneList(Clerk.ClerkReady);
            DeliveryMan.cloneList(DeliveryMan.DeliveryMansReady);
            InitializeComponent();
            FrameShow.Content = new ShowOldCommands(FrameShow);
            BtnShowCustomers.Opacity = 0.5;
            BtnShowCommands.Opacity = 1;
            //calc nb of clients beforehand
            foreach (Clerk c in Clerk.ListOfClerks)
            {
                Console.WriteLine(c.getMyCommands()+" give "+c.cptCmd);
            }
            DgClerks.ItemsSource = Clerk.ListOfClerkWorking();
            //DgCustomers.ItemsSource = Clerk.ListOfCustomers();
            DgDeliveryMan.ItemsSource = DeliveryMan.getAllDeliveryMen(); 
            LblAvgCommande.Text = CommandReader.avg.ToString();
            Console.WriteLine("avg tostring " + CommandReader.avg.ToString());
            LblAvgAcount.Text = Clerk.getAvgAccount().ToString();
        }
        public void BtnShowCustomers_Click(object sender, RoutedEventArgs e)
        {
            FrameShow.Content = new ShowCustomers(FrameShow);
            BtnShowCustomers.Opacity = 1;
            BtnShowCommands.Opacity = 0.5;
        }
        public void BtnShowCommands_Click(object sender, RoutedEventArgs e)
        {
            FrameShow.Content = new ShowOldCommands(FrameShow);
            BtnShowCustomers.Opacity = 0.5;
            BtnShowCommands.Opacity = 1;
        }

    }


}
