
using EmployeeToolEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeToolModels;


namespace EmployeeLayer.Controllers
{
    public class EmployeeEFController : ApiController
    {
        private EmployeeOperationEf emp = new EmployeeOperationEf();

        [Route("api/EmployeeEF/AddEmployee")]
        [HttpPost]
        public int AddEmployee(EmployeeModel employeeModel)
        {
            int n = emp.AddEmployee(employeeModel);
            return n;
        }

        [Route("api/EmployeeEF/Edit")]
        [HttpPost]
        public void Edit(EmployeeModel employeeModel)
        {

            emp.Edit(employeeModel);
        }

        [Route("api/EmployeeEF/Delete")]
        [HttpPost]

        public void Delete(string id)
        {
            emp.Delete(id);
        }

        [Route("api/EmployeeEF/GetAll")]
        [HttpPost]
        public List<EmployeeModel> GetAll()
        {
            List<EmployeeModel> lst = new List<EmployeeModel>();
            lst = emp.GetAll();
            return lst;
        }

        [Route("api/EmployeeEF/Get")]
        [HttpPost]
        public EmployeeModel Get(string id)
        {

            return emp.Get(id);
        }
    }
}