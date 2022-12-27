using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Demo.Model
{
    public class EmployeeService
    {
        private static List<Employee> objEmployeesList;

        public EmployeeService()
        {
            objEmployeesList=new List<Employee>();
        }
        //________________________________________________________________________
        public List<Employee> GetAll()
        {
            return objEmployeesList;
        }
        //________________________________________________________________________
        public bool Add(Employee objNewEmployee)
        {
            // Age must between 21 and 58
            if (objNewEmployee.Age<21 || objNewEmployee.Age>58)
                throw new ArgumentException("Invalid age limit for employee");

            objEmployeesList.Add(objNewEmployee);
            return true;
        }
        //________________________________________________________________________
        public bool Update(Employee objEmployeeToUpdate)
        {
            bool IsUpdate = false;
            for (int index = 0; index<objEmployeesList.Count; index++)
            {
                if (objEmployeesList[index].Id==objEmployeeToUpdate.Id)
                {
                    objEmployeesList[index].Name=objEmployeeToUpdate.Name;
                    objEmployeesList[index].Age=objEmployeeToUpdate.Age;
                    IsUpdate=true;
                    break;
                }
            }
            return IsUpdate;
        }
        //________________________________________________________________________
        public bool Delete(int id)
        {
            bool IsDeleted = false;
            for (int index = 0; index<objEmployeesList.Count; index++)
            {
                if (objEmployeesList[index].Id==id)
                {
                    try
                    {
                        objEmployeesList.RemoveAt(index);
                        IsDeleted = true;
                    }
                    catch (Exception)
                    {

                    }
                }
            }
            return IsDeleted;
        }
        //_________________________________________________________________
        public Employee Search(int id)
        {
            return objEmployeesList.FirstOrDefault(e => e.Id==id);
        }
        //_________________________________________________________________
    }
}

