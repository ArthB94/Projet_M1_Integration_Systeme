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
        private string phoneNumber;
        private string surname;
        private int id;
        public static int IDS { get; set; } = 0;
        private DateTime firstCommandDate;
        private Address address;

        public Customer(string phoneNumber, string name, string surname) : base(name)
        {
            IDS++;
            id = IDS;
            this.phoneNumber = phoneNumber;
            this.name = name;
            this.surname = surname;
        }
        public Customer(string phoneNumber, string name, string surname, Address address) : base(name)
        {
            IDS++;
            id = IDS;
            this.phoneNumber = phoneNumber;
            this.name = name;
            this.surname = surname;
            this.address = address;
        }
        [JsonConstructor]
        public Customer(string phoneNumber, string name, string surname, Address address, int id, DateTime FirstCommandDate) : base(name)
        {
            IDS++;
            this.phoneNumber = phoneNumber;
            this.name = name;
            this.surname = surname;
            this.address = address;
            this.id = id;
            this.FirstCommandDate = FirstCommandDate;
        }


        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

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

        // order(int id):void qui fait appel Ã  la fonction order de clerk??
    }
}