﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Demo.Model
{
    public class Employee : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged !=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private int id;
        public int Id
        {
            get { return id; }
            set { id=value; OnPropertyChanged("Id"); }
        }
        private String name;
        public string Name
        {
            get { return name; }
            set { name=value; OnPropertyChanged("Name"); }
        }
        private int age;
        public int Age
        {
            get { return age; }
            set { age=value; OnPropertyChanged("Age"); }
        }

    }// class
}

