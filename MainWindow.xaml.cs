
using System.Windows;
using System.Collections.Generic;
using System.Windows.Controls;
using Projet_M1_Integration_Systeme.Pages;
using Projet_M1_Integration_Systeme.Pages.Pannel;
using System.Linq;

namespace Projet_M1_Integration_Systeme
{

    public partial class MainWindow : Window
    {

        public Kitchen kitchen { get; set; }
        public List<Page> Pages { get; set; }
        public int CurrentPageIndex { get; set; }
        public Page CurrentPage => Pages[CurrentPageIndex]; 
        public CommandsStatusPage CommandsStatusPannel { get; set; }
        


        public MainWindow()
        {
            kitchen = new Kitchen();
            List<CommandReader> commands = Clerk.LoadCommands();
            if (commands.Count() > 0)
            {
                Command.IDS = commands.Last().Id;
            }
            List<Customer> customers = Clerk.LoadCustomers();
            if (customers.Count() > 0)
            {
                Customer.IDS = customers.Last().Id;
            }

            CommandsStatusPannel = new CommandsStatusPage();
            CurrentPageIndex = 0;

            // permet d'initialiser la page de connexion au lancement de l'application donc le fichiers xaml (Attention à bien d'initialises dans cette fonction tout ce qui est nécessaire avant d'initialiser la page xaml)
            InitializeComponent();
            if (CurrentPageIndex != 0)
            {
               /* Clerk clerk = Clerk.CallPizzaria();
                Customer customer = new Customer("0000000000","Default","Default");
                clerk.StoreCustomer(customer);*//*
                Pages = new List<Page>
                {
                    new ConnectionPage(InteractiveFrame),
                    new CustomerPage(InteractiveFrame,clerk),
                    new CommandPage(InteractiveFrame,clerk),
                };*/
            }
            else
            {
                Pages = new List<Page>
                {
                    new ConnectionPage(InteractiveFrame),
                };
            }

            // initialise la page première page de la liste

            InteractiveFrame.Content = CurrentPage;
            CommandsStatusFrame.Content = CommandsStatusPannel;
            StatisticsFrame.Content = new StatisticsPage();
            

        }

        // permet de passer à la page suivante
        public void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentPageIndex < Pages.Count - 1)
            {
                CurrentPageIndex++;
                InteractiveFrame.Content = CurrentPage;
            }
        }

        // permet de passer à la page précédente
        public void BtnPrevious_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentPageIndex > 0)
            {
                CurrentPageIndex--;
                InteractiveFrame.Content = CurrentPage;
            }
        }

        // permet de naviguer vers une page spécifique
        public void NavigateToPage(int pageIndex)
        {
            CurrentPageIndex = pageIndex;
            InteractiveFrame.Content = CurrentPage;
        }
    }
}
