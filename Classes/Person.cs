using System;
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