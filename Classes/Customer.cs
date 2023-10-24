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
        private string surname;
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

        public string Surname
        {
            get { return surname; }
            set
            {
                surname = value;
                OnPropertyChanged(nameof(Surname));
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

        public event PropertyChangedEventHandler PropertyChanged;

        // order(int id):void qui fait appel à la fonction order de clerk??
    }
}
