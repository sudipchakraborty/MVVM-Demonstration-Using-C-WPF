using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Demo.Model
{
    public class number:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged !=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private string numberA;
        public string NumberA
        {
            get { return numberA; }
            set { numberA=value; OnPropertyChanged("NumberA");}
        }
        private string numberB;
        public string NumberB
        {
            get { return numberB; }
            set { numberB=value; OnPropertyChanged("NumberB"); }
        }
        private int result;
        public int Result
        {
            get { return result; }
            set { result=value; OnPropertyChanged("Result"); }
        }
    }
}
