using Projet_M1_Integration_Systeme.Pages.Pannel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projet_M1_Integration_Systeme
{

    public partial class MainWindow : Window
    {
        public List<Page> Pages { get; set; }
        public int CurrentPageIndex { get; set; }
        public Page CurrentPage => Pages[CurrentPageIndex];
        public CommandsPannel commandsPannel { get; set; }

        public ObservableCollection<PizzaViewModel> PizzasCommande { get; set; }
        public ObservableCollection<PizzaViewModel> PizzaInPreparation { get; set; }
        public ObservableCollection<PizzaViewModel> PizzaReady { get; set; }
        public ObservableCollection<PizzaViewModel> PizzaDelivered { get; set; }

        public MainWindow()
        {
            // permet de créer une liste de pizzas utilisable dans toute l'application et de l'initialiser avec une pizza par défaut
            PizzasCommande = new ObservableCollection<PizzaViewModel>
            {
                new PizzaViewModel(new Pizza ()),
            };
            PizzaInPreparation = new ObservableCollection<PizzaViewModel>();
            PizzaReady = new ObservableCollection<PizzaViewModel>();
            PizzaDelivered = new ObservableCollection<PizzaViewModel>();
            // permet de créer une liste de pages a parcourir
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
            CurrentPageIndex = 0;
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
