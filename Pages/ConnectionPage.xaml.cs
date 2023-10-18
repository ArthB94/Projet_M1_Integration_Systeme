using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Logique d'interaction pour ConnectionPage.xaml
    /// </summary>
    public partial class ConnectionPage : Page
    {
        MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;

        public bool IsButtonEnabled => NameTextBox.Text.Length > 0
            && SurnameTextBox.Text.Length > 0 && PhoneNumberTextBox.Text.Length == 10;




        public ConnectionPage()
        {

            InitializeComponent();

            VerifyIsEmpty();
            NameTextBox.TextChanged += (sender, args) => VerifyIsEmpty();
            SurnameTextBox.TextChanged += (sender, args) => VerifyIsEmpty();
            PhoneNumberTextBox.TextChanged += (sender, args) => VerifyIsEmpty();

            PhoneNumberTextBox.PreviewTextInput += Number_PreviewTextInput;
            PhoneNumberTextBox.MaxLength = 10;
            NameTextBox.PreviewTextInput += String_PreviewTextInput;
            SurnameTextBox.PreviewTextInput += String_PreviewTextInput;

        }

        private void Number_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            // Utilisez une expression régulière pour autoriser uniquement les chiffres
            if (!Regex.IsMatch(e.Text, "^[0-9]+$"))
            {
                e.Handled = true; // Empêche la saisie du texte non numérique
            }
        }

        private void String_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            // Utilisez une expression régulière pour autoriser uniquement les lettres
            if (!Regex.IsMatch(e.Text, "^[a-zA-Z]+$"))
            {
                e.Handled = true; // Empêche la saisie du texte non alphabétique
            }
        }

        private void VerifyIsEmpty()
        {
            BtnConnection.IsEnabled = IsButtonEnabled;
            if (IsButtonEnabled)
            {
                ErrorLabel.Content = "";
            }
            else
            {
                ErrorLabel.Content = "Every input must be empty";
            }
        }


        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.BtnNext_Click(sender, e);
        }

        private void BtnConnection_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.CurrentPageIndex = 2;
            mainWindow.MainFrame.Content = mainWindow.CurrentPage;
        }
    }
}
