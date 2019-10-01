using EmployeeToolModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeToolInterfaces
{
   public  interface ISalaryCrud
    {
        int AddSalary(SalaryModel salaryModel);
        void Edit(SalaryModel salaryModel);
        void Delete(string id);
       List<SalaryModel> GetAll();
        SalaryModel Get(string id);//object
    }
}
