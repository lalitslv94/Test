using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EmployeeToolModels;
using EF.Model;

namespace EmployeeManagement.interfaces.EF
{
   
        public interface IEmployeeCrudEf
        {
            int AddEmployee(global::EF.Model.EmployeeModel employeeModel);
            void Edit(global::EF.Model.EmployeeModel employeeModel);
            void Delete(string id);
            List<EmployeeToolModels.EmployeeModel> GetAll();//list of emp model
        EmployeeModel Get(string id);//object

        }
    }

