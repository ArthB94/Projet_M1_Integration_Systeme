﻿
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;


namespace Projet_M1_Integration_Systeme.Pages
{
    /// <summary>
    /// Logique d'interaction pour ConnectionPage.xaml
    /// </summary>
    public partial class ConnectionPage : Page
    {
        // permet de récupérer touts les elements initialisés dans MainWindow
        MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
        Frame  FrameShow{ get; set;}

        // permet de vérifier si les champs repectent toutes les conditions nécessaires
        public bool IsButtonEnabled => NameTextBox.Text.Length > 0
            && SurnameTextBox.Text.Length > 0 && PhoneNumberTextBox.Text.Length == 10;

        public ConnectionPage(Frame frameshow)
        {

            InitializeComponent();

            FrameShow = frameshow;

            // permet de vérifier si les champs sont vides a chaque fois que un input est modifié
            VerifyIsEmpty();
            NameTextBox.TextChanged += (sender, args) => VerifyIsEmpty();
            SurnameTextBox.TextChanged += (sender, args) => VerifyIsEmpty();
            PhoneNumberTextBox.TextChanged += (sender, args) => VerifyIsEmpty();

            // empêche la saisie de caractères non numériques
            PhoneNumberTextBox.PreviewTextInput += Number_PreviewTextInput;
            PhoneNumberTextBox.MaxLength = 10;

            // empêche la saisie de caractères non alphabétiques
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

        // permet de vérifier si les champs sont vides et affiche un message d'erreur si nécessaire
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

        // permet de passer à la page suivante
        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            Clerk clerk = Clerk.CallPizzaria();
            FrameShow.Navigate(new CustomerPage(FrameShow, clerk));
        }

        // permet de passer directement à la page de commande
        private void BtnConnection_Click(object sender, RoutedEventArgs e)
        {
            // string name = NameTextBox.Text;
            Clerk clerk = Clerk.CallPizzaria();
            if (clerk == null)
            {
                MessageBox.Show("Erreur aucun clerk disponible");
                return;
            }
            if (clerk.ConnectCustomer(PhoneNumberTextBox.Text))
            {
                FrameShow.Navigate(new CommandPage(FrameShow, clerk));
            }
            else
            {
                MessageBox.Show("Vous n'êtes pas dans la base de données, veuillez vous inscrire.");
                mainWindow.NavigateToPage(1);
            }
        }
    }
}
