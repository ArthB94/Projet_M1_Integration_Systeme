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
    /// Logique d'interaction pour ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;

        // permet de vérifier si les champs repectent toutes les conditions nécessaires
        public bool IsButtonEnabled => NameTextBox.Text.Length > 0 
            && SurnameTextBox.Text.Length > 0 && PhoneNumberTextBox.Text.Length == 10
            && NumberTextBox.Text.Length > 0 && StreetTextBox.Text.Length > 0 && CityTextBox.Text.Length > 0
            && PostalCodeTextBox.Text.Length == 5 && CountryTextBox.Text.Length > 0;


        public ClientPage()
        {

            InitializeComponent();

            // permet de vérifier si les champs sont vides
            VerifyIsEmpty();
            // permet de vérifier si les champs sont vides apres chaque modification
            NameTextBox.TextChanged += (sender, args) => VerifyIsEmpty();
            SurnameTextBox.TextChanged += (sender, args) => VerifyIsEmpty();
            PhoneNumberTextBox.TextChanged += (sender, args) => VerifyIsEmpty();
            NumberTextBox.TextChanged += (sender, args) => VerifyIsEmpty();
            StreetTextBox.TextChanged += (sender, args) => VerifyIsEmpty();
            CityTextBox.TextChanged += (sender, args) => VerifyIsEmpty();
            PostalCodeTextBox.TextChanged += (sender, args) => VerifyIsEmpty();
            CountryTextBox.TextChanged += (sender, args) => VerifyIsEmpty();

            //empêche la saisie de caractères non numériques
            PhoneNumberTextBox.PreviewTextInput += Number_PreviewTextInput;
            PhoneNumberTextBox.MaxLength = 10;
            NumberTextBox.PreviewTextInput += Number_PreviewTextInput;
            PostalCodeTextBox.PreviewTextInput += Number_PreviewTextInput;
            PostalCodeTextBox.MaxLength = 5;

            // empêche la saisie de caractères non alphabétiques
            CountryTextBox.PreviewTextInput += String_PreviewTextInput;
            CityTextBox.PreviewTextInput += String_PreviewTextInput;
            NameTextBox.PreviewTextInput += String_PreviewTextInput;
            SurnameTextBox.PreviewTextInput += String_PreviewTextInput;
            StreetTextBox.PreviewTextInput += String_PreviewTextInput;

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
            BtnNext.IsEnabled = IsButtonEnabled;
            if (IsButtonEnabled)
            {
                ErrorLabel.Content = "";
            }
            else
            {
                ErrorLabel.Content = "Every input must be filled";
            }
        }   

        // permet de passer à la page suivante
        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            Address address = new Address(NumberTextBox.Text, StreetTextBox.Text, CityTextBox.Text, PostalCodeTextBox.Text, CountryTextBox.Text);
            Customer customer = new Customer(PhoneNumberTextBox.Text, NameTextBox.Text, SurnameTextBox.Text,address);
            mainWindow.clerk.StoreCustomer(customer);
            mainWindow.BtnNext_Click(sender, e);
        }
        // permet de revenir à la page précédente
        public void BtnPrevious_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.BtnPrevious_Click(sender, e);
        }
    }
}
