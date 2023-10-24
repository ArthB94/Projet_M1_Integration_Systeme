
using System.Windows;
using System.Collections.Generic;
using System.Windows.Controls;
using Projet_M1_Integration_Systeme.Pages;
using Projet_M1_Integration_Systeme.Pages.Pannel;

namespace Projet_M1_Integration_Systeme
{

    public partial class MainWindow : Window
    {
        public Clerk clerk { get; set; }
        public Kitchen kitchen { get; set; }
        public DeliveryMan deliveryMan { get; set; }
        public Customer currentCustomer { get; set; }
        public List<Page> Pages { get; set; }
        public int CurrentPageIndex { get; set; }
        public Page CurrentPage => Pages[CurrentPageIndex];
        public CommandsStatusPage CommandsStatusPannel { get; set; }
        


        public MainWindow()
        {
            currentCustomer = new Customer("1111111111", "Jaky","Jack");
            clerk = new Clerk(1, "Jean");
            deliveryMan = new DeliveryMan("Pierre");
            kitchen = new Kitchen();

            CommandsStatusPannel = new CommandsStatusPage();

            Pages = new List<Page>
            {
                new ConnectionPage(),
                new CustomerPage(),
                new CommandPage(),
            };

            // permet d'initialiser la page de connexion au lancement de l'application donc le fichiers xaml (Attention à bien d'initialises dans cette fonction tout ce qui est nécessaire avant d'initialiser la page xaml)
            InitializeComponent();

            // initialise la page première page de la liste
            CurrentPageIndex = 2;
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
