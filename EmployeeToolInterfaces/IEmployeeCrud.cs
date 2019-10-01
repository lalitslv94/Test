using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using EmployeeToolModels;

namespace EmployeeToolInterfaces
{
  public  interface IEmployeeCrud
    {
        int AddEmployee(EmployeeModel employeeModel);
        void Edit(EmployeeModel employeeModel);
        void Delete(string id);
       List<EmployeeModel > GetAll();//list of emp model
        EmployeeModel Get(string empreq);//object

    }
}
