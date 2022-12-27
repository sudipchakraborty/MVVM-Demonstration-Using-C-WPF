using MVVM_Demo.Command;
using MVVM_Demo.Model;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Demo.ViewModel
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        #region Inotify change
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged !=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
        EmployeeService objEmployeeService;
        public EmployeeViewModel()
        {
            objEmployeeService= new EmployeeService();
            LoadData();
            CurrentEmployee     =new Employee();
            SaveCommand=new RelayCommand(Save);
            searchCommand=new RelayCommand(Search);
            updateCommand=new RelayCommand(Update);
            deleteCommand=new RelayCommand(Delete);
        }
        #region Display Operation
        private ObservableCollection<Employee> employeesList;
        public ObservableCollection<Employee> EmployeesList
        {
            get { return employeesList; }
            set { employeesList = value; OnPropertyChanged("EmployeesList"); }
        }
        private void LoadData()
        {
            EmployeesList=new ObservableCollection<Employee>(objEmployeeService.GetAll());
        }
        #endregion
        private Employee currentEmployee;
        public Employee CurrentEmployee
        {
            get { return currentEmployee; }
            set { currentEmployee=value; OnPropertyChanged("CurrentEmployee"); }
        }
        private string message;
        public string Message
        {
            get { return message; }
            set { message=value; OnPropertyChanged("Message"); }
        }
        #region SaveOperation
        private RelayCommand saveCommand;

        public RelayCommand SaveCommand
        {
            get { return saveCommand; }
            set { saveCommand = value; }
        }
        public void Save()
        {
            try
            {
                Employee emp = new Employee();
                emp.Id=CurrentEmployee.Id;
                emp.Name=CurrentEmployee.Name;
                emp.Age=CurrentEmployee.Age;

                var IsSaved = objEmployeeService.Add(emp);
                LoadData();
                if (IsSaved) Message="Employee Saved";
                else
                    Message="Save Operation Failed";
            }
            catch (Exception ex)
            {
                Message=ex.Message;
            }
        }

        #endregion

        #region SearchOperation
        private RelayCommand searchCommand;

        public RelayCommand SearchCommand
        {
            get
            {
                return searchCommand;
            }
            set
            {
                searchCommand = value;
            }
        }

        public void Search()
        {
            try
            {
                var ObjEmployee = objEmployeeService.Search(CurrentEmployee.Id);
                if (ObjEmployee!= null)
                {
                    CurrentEmployee.Name= ObjEmployee.Name;
                    CurrentEmployee.Age= ObjEmployee.Age;
                }
                else
                {
                    Message="Employee Not found";
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region UpdateOperation
        private RelayCommand updateCommand;

        public RelayCommand UpdateCommand
        {
            get
            {
                return updateCommand;
            }
        }

        public void Update()
        {
            try
            {
                var IsUpdated = objEmployeeService.Update(CurrentEmployee);
                if (IsUpdated)
                {
                    Message="Employee Updated";
                    LoadData();
                }
                else
                {
                    Message="Update Operation Failed";
                }
            }
            catch (Exception ex)
            {

                Message=ex.Message;
            }
        }
        #endregion


        #region DeleteOperation

        private RelayCommand deleteCommand;

        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand;
            }
        }

        public void Delete()
        {
            try
            {
                var IsDelete = objEmployeeService.Delete(CurrentEmployee.Id);
                if (IsDelete)
                {
                    Message="Employee deleted";
                    LoadData();
                }
                else
                {
                    Message="Delete Operation Failed";
                }
            }
            catch (Exception ex)
            {

                Message=ex.Message;
            }
        }

        #endregion
    }
}

