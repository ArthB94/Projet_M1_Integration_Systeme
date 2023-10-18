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
            Pizzas = new ObservableCollection<PizzaViewModel>
            {
                new PizzaViewModel(new Pizza ()),
            };
            Pages = new List<Page>
            {
                new CommandePage(),
                new CommandsPannel(),
            };

            InitializeComponent();

        }

        public void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentPageIndex < Pages.Count - 1)
            {
                CurrentPageIndex++;
                MainFrame.Content = CurrentPage;
            }
        }

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
