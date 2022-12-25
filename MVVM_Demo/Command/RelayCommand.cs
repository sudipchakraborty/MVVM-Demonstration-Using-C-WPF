﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM_Demo.Command
{
    public class RelayCommand:ICommand
    {
        public event EventHandler CanExecuteChanged;
        public Action DoWork;

        public RelayCommand(Action work)
        {
            DoWork= work;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            DoWork();
        }
    }
}
