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

namespace Projet_M1_Integration_Systeme.Pages.Pannel
{
    /// <summary>
    /// Logique d'interaction pour ShowOldDetails.xaml
    /// </summary>
    public partial class ShowOldDetails : Page
    {
        public Frame FrameShow { get; set; }
        public ShowOldDetails(Frame frameShow, CommandReader command )
        {
            FrameShow = frameShow;
            InitializeComponent();
            DgPizzas.ItemsSource = command.ToCommande().Pizzas;
            DgDrinks.ItemsSource = command.ToCommande().Drinks;
            LblClientNameValue.Text = command.CustomerFullName;
            LblDeliveryDateValue.Text = command.Date_time;
            LblTotalPriceValue.Text = command.Price.ToString();
            LblStatus.Text = command.Status;
        }
        public void BtnShow_Click(object sender, RoutedEventArgs e)
        {
               FrameShow.Navigate(new ShowOldCommands(FrameShow));
        }
    }
}
