using System;
using System.Collections.Generic;
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
using Projet_M1_Integration_Systeme.Pages;
using Projet_M1_Integration_Systeme;


namespace Projet_M1_Integration_Systeme.Pages.Pannel
{
    /// <summary>
    /// Logique d'interaction pour ShowUsers.xaml
    /// </summary>
    public partial class ShowCustomers : Page
    {
        public Frame FrameShow { get; set; }
        public MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
        public ShowCustomers(Frame frameShow)
        {
            FrameShow = frameShow;
            InitializeComponent();

            DgCustomers.ItemsSource = Clerk.LoadCustomers();
        }
        public void BtnShow_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (button.DataContext is Customer customer)
                {
                    FrameShow.Navigate(new CustomerPage(FrameShow, customer));
                }
            }
        }
        public void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            var Search = TxtSearch.Text;
            if (Search != null)
            {
                // tu peux changer cette ligne pour faire une recherche dans la base de données
                //DgCustomers.ItemsSource = mainWindow.clerk.LoadCustomers();
            }
            else
            {
                DgCustomers.ItemsSource = Clerk.LoadCustomers();
            }

        }
    }
}
