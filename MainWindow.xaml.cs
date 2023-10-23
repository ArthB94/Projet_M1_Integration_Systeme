
using System.Windows;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Projet_M1_Integration_Systeme
{

    public partial class MainWindow : Window
    {
        public Clerk clerk { get; set; }
        public Kitchen kitchen { get; set; }
        public DeliveryMan deliveryMan { get; set; }
        public List<Page> Pages { get; set; }
        public int CurrentPageIndex { get; set; }
        public Page CurrentPage => Pages[CurrentPageIndex];
        public CommandsPannel commandsPannel { get; set; }


        public MainWindow()
        {
            clerk = new Clerk(1, "Jean");
            deliveryMan = new DeliveryMan();
            kitchen = new Kitchen();

            commandsPannel = new CommandsPannel();

            Pages = new List<Page>
            {
                new ConnectionPage(),
                new ClientPage(),
                new CommandePage(),
            };

            // permet d'initialiser la page de connexion au lancement de l'application donc le fichiers xaml (Attention à bien d'initialises dans cette fonction tout ce qui est nécessaire avant d'initialiser la page xaml)
            InitializeComponent();

            // initialise la page première page de la liste
            CurrentPageIndex = 2;
            MainFrame.Content = CurrentPage;
            CommandsPannelFrame.Content = commandsPannel;
            

        }

        // permet de passer à la page suivante
        public void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentPageIndex < Pages.Count - 1)
            {
                CurrentPageIndex++;
                MainFrame.Content = CurrentPage;
            }
        }

        // permet de passer à la page précédente
        public void BtnPrevious_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentPageIndex > 0)
            {
                CurrentPageIndex--;
                MainFrame.Content = CurrentPage;
            }
        }

        // permet de naviguer vers une page spécifique
        public void NaviateToPage(int pageIndex)
        {
            CurrentPageIndex = pageIndex;
            MainFrame.Content = CurrentPage;
        }



        

    }
}
