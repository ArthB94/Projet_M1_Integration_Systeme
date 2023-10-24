using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Projet_M1_Integration_Systeme
{
    public class Address : INotifyPropertyChanged
    {
        private int number;
        private string street;
        private string city;
        private double postalCode;
        private string country;

        public Address(int number, string street, string city, double postalCode, string country)
        {
            this.number = number;
            this.street = street;
            this.city = city;
            this.postalCode = postalCode;
            this.country = country;
        }

        public int Number
        {
            get { return number; }
            set
            {
                if (value is int)
                {
                    number = value;
                    OnPropertyChanged(nameof(Number));
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

        public string Street
        {
            get { return street; }
            set
            {
                street = value;
                OnPropertyChanged(nameof(Street));
            }
        }

        public string City
        {
            get { return city; }
            set
            {
                city = value;
                OnPropertyChanged(nameof(City));
            }
        }
        public double PostalCode
        {
            get { return postalCode; }
            set
            {
                if (value is double)
                {
                    postalCode = value;
                    OnPropertyChanged(nameof(PostalCode));
                }
                else
                {
                    Console.WriteLine("Error: You can only enter numbers");
                }
                
            }
        }
        public string Country
        {
            get { return country; }
            set
            {
                country = value;
                OnPropertyChanged(nameof(Country));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
