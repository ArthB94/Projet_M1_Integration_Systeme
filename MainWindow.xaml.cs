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

        public ObservableCollection<PizzaViewModel> Pizzas { get; set; }
        public MainWindow()
        {
            // permet de créer une liste de pizzas utilisable dans toute l'application
            Pizzas = new ObservableCollection<PizzaViewModel>
            {
                new PizzaViewModel(new Pizza ()),
            };

            // permet de créer une liste de pages a parcourir
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


        

    }
}
