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
        private string number;
        private string street;
        private string city;
        private string postalCode;
        private string country;

        public Address(string number, string street, string city, string postalCode, string country)
        {
            this.number = number;
            this.street = street;
            this.city = city;
            this.postalCode = postalCode;
            this.country = country;
        }

        public string Number
        {
            get { return number; }
            set
            {
                number = value;
                OnPropertyChanged(nameof(Number));
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

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
        public string PostalCode
        {
            get { return postalCode; }
            set
            {
                    postalCode = value;
                    OnPropertyChanged(nameof(PostalCode));
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
