using MVVM_Demo.Command;
using MVVM_Demo.Model;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Demo.ViewModel
{
    public class NumberViewModel:INotifyPropertyChanged
    {
        NumberService numserve;
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged !=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public NumberViewModel()
        { 
            numserve= new NumberService();
        }
        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get { return addCommand; }
            set { addCommand = value;}
        }
        public void Save()
        {
            try
            {
                numserve.add();
            }
            catch (Exception ex)
            {
               string Message=ex.Message;
            }
        }
    }
}
