using EmployeeToolInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EmployeeToolModels;
using EFModels;

namespace EmployeeToolEF
{
    public class  EmployeeOperationEf:IEmployeeCrud
    {
        EmpManagement e =new EmpManagement();
        public int AddEmployee(EmployeeModel employeeModel)
        {
           
            e.Employees.Add(employeeModel);
             int n=  e.SaveChanges();
            return n;
        }

        public void Edit(EmployeeModel employeeModel)
        {
            var editedValue=e.Employees.FirstOrDefault(b => b.Id == employeeModel.Id);
            editedValue.Name = employeeModel.Name;
            e.SaveChanges();
        }

        public void Delete(string id)
        {
            int Id = Convert.ToInt32(id);
            var deleteValue = e.Employees.Where(c => c.Id == Id).FirstOrDefault();
            var deleteValued = e.Employees.FirstOrDefault(c => c.Id == Id);
            // e.Employees.Remove(deleteValue);
            e.SaveChanges();
        }

        public List<EmployeeModel> GetAll()
        {
            List<EmployeeModel> lst = new List<EmployeeModel>();
            var getAll = e.Employees.ToList();
            EmployeeModel e2=new EmployeeModel();
            foreach (var employee in getAll)
            {
                e2.Name = employee.Name;
               // Console.WriteLine(e2.Name);
                lst.Add(e2);
                Console.WriteLine(e2.Name);
            }
            
return lst;
        }


        public EmployeeModel Get(string id)
        {
          EmployeeModel e1=new EmployeeModel();
            int Id = Convert.ToInt32(id);
            var editedValue = e.Employees.Where(s => s.Id == Id);
            foreach (var VARIABLE in editedValue)
            {
                e1.Name = VARIABLE.Name;
                Console.WriteLine(e1.Name);
            }
            
            return e1;
        }
    }
}
