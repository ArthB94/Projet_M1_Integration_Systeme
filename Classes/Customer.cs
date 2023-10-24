using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Markup;
using Newtonsoft.Json;

namespace Projet_M1_Integration_Systeme
{
    public class Customer : Person
    {
        private int phoneNumber;
        private string name;
        private string firstName;
        private int id;
        private DateTime firstCommandDate;
        private Address address;

        public Customer(int phoneNumber, string name) : base(name) 
        {
            this.phoneNumber = phoneNumber;
        }

        public int PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                if (value is int)
                {
                    phoneNumber = value;
                    OnPropertyChanged(nameof(PhoneNumber));
                }
                else
                {
                    Console.WriteLine("Error: You can only enter numbers");
                }
            }
        }

        private void OnPropertyChanged(string v)
        {
            throw new NotImplementedException();
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        public DateTime FirstCommandDate
        {
            get { return firstCommandDate; }
            set
            {
                firstCommandDate = value;
                OnPropertyChanged(nameof(FirstCommandDate));
            }
        }
        public Address Address
        {
            get { return address; }
            set
            {
                address = value;
                OnPropertyChanged(nameof(Address));
            }
        }

        public static List<Customer> LoadCustomers()
        {
            string jsonFileSource = Directory.GetCurrentDirectory() + "/../../JSONFiles/";
            string jsonContent = File.ReadAllText(jsonFileSource + "Customers.json");
            return JsonConvert.DeserializeObject<List<Customer>>(jsonContent);
        }

        public static Customer ConnectCustomer(string name)
        {
            List<Customer> customers = LoadCustomers();
            Customer foundCustomer = customers.Find(customer => customer.Name == name);
            if (foundCustomer != null)
            {
                return foundCustomer;
            }
            else
            {
                Console.WriteLine("Client non enregistré dans la base de données");
                return null;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // order(int id):void qui fait appel à la fonction order de clerk??
    }
}
