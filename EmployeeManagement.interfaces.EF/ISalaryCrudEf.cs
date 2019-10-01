using System.Collections.Generic;

using EmployeeToolModels;

namespace EmployeeManagement.interfaces.EF
{
   public  interface ISalaryCrudEf
    {
        int AddSalary(SalaryModel salaryModel);
        void Edit(SalaryModel salaryModel);
        void Delete(string id);
       List<SalaryModel> GetAll();
        SalaryModel Get(string id);//object
    }
}
