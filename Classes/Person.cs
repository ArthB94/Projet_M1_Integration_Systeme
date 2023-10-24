using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Markup;
using Newtonsoft.Json;

namespace Projet_M1_Integration_Systeme
{
    public abstract class Person : INotifyPropertyChanged
    {
        public string name { get; set; }

        public Person(string name)
        {
            this.name = name;
        }
    }
}