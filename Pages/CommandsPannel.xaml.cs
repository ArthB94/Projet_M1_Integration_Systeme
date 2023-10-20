using Projet_M1_Integration_Systeme.Pages.Pannel;
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

namespace Projet_M1_Integration_Systeme
{
    /// <summary>
    /// Logique d'interaction pour CommandsPannel.xaml
    /// </summary>
    public partial class CommandsPannel : Page
    {
        public MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
        public List<PizzaViewModel> PizzaViewModelInPreparation { get; set; }

        public InPreparationPanel InPreparationPanel { get; set; }
        

        public CommandsPannel()
        {
            InPreparationPanel InPreparationPanel = new InPreparationPanel();

            InitializeComponent();
            FrameCommande.Content = InPreparationPanel;

        }

        public async Task LaunchPreparation()
        {
            Console.WriteLine("LaunchPreparation");

            await Task.WhenAll(LaunchOneCook(),LaunchOneCook());



        }
        public async Task LaunchOneCook()
        {
            Console.WriteLine("LaunchOneCook");
            while (mainWindow.PizzaInPreparation.Count > 0)
            {
                var IndexPizza = 0;
                while (mainWindow.PizzaInPreparation[IndexPizza].Pizza.Status != "Waiting")
                {
                    IndexPizza++;
                    if (IndexPizza > mainWindow.PizzaInPreparation.Count - 1)
                    {
                        Console.WriteLine("LaunchOneCookFinished");
                        return;
                    }

                }
                PizzaViewModel pizzaView = mainWindow.PizzaInPreparation[IndexPizza];
                await pizzaView.Pizza.Prepare();
                mainWindow.PizzaReady.Add(pizzaView);
                mainWindow.PizzaInPreparation.Remove(pizzaView);

            }

        }

    }
}
