using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeToolAdoNet;
using EmployeeToolModels;

namespace EmployeeLayer.Controllers
{
    public class SalaryController : ApiController
    {
        private SalaryOperations s = new SalaryOperations();
        [Route("api/Salary/AddSalary")]
        public int AddSalary(SalaryModel salaryModel)
        {
            return s.AddSalary(salaryModel);
        }
        [Route("api/Salary/Edit")]
        public void Edit(SalaryModel salaryModel)
        {
            s.Edit(salaryModel);
        }
        [Route("api/Salary/DeleteSalary")]
        public void Delete(string id)
        {
            s.Delete(id);
        }

        public List<SalaryModel> GetAll()
        {
            List<SalaryModel> lst = new List<SalaryModel>();
            return lst;
        }
        public SalaryModel Get(string id)
        {
           // SalaryModel e = new SalaryModel();
            return s.Get(id);
        }
}

}
