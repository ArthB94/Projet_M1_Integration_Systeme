using System;

public abstract class Person : INotifyPropertyChanged
{
    public string name { get; set; }

    public Person(string name)
    {
        this.name = name;
    }
}