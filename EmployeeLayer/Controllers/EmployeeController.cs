using EmployeeToolAdoNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeToolModels;

namespace EmployeeLayer.Controllers
{
    public class EmployeeController : ApiController
    {

        private EmployeeOperation e = new EmployeeOperation();
       
        [Route("api/Employee/AddEmployee")]
        [HttpPost]
        public int Add (EmployeeModel employeeModel)
        {

            return e.AddEmployee(employeeModel);

        }
        [Route("api/Employee/Edit")]
        [HttpPost]
        public void Edit(EmployeeModel employeeModel)
        {
            e.Edit(employeeModel);
            }

        [Route("api/Delete1/{id}")]
        [HttpPost]
        public void Delete([FromUri] string id)
        {
            EmployeeRequestObject ep =new EmployeeRequestObject();

            int Empid;

            //int i = ep.Id;

            //ep.Id = id;
            //string s = i.ToString();
           // Empid = Convert.ToInt32(id);
            
            e.Delete(id);
        }

        [Route("api/Employee/GetAll")]
        [HttpPost]
        public List<EmployeeModel> GetAll()
        {
            List<EmployeeModel> lst = new List<EmployeeModel>();
            lst = e.GetAll();
            return lst;
        }
        [Route("api/Employee/Get/{Empid}")]
        [HttpPost]
        public EmployeeModel Get(string Empid)
        {
          //EmployeeModel e1=new EmployeeModel();
            EmployeeRequestObject e2=new EmployeeRequestObject();
            int id = Convert.ToInt32(Empid);
           // e2.Id = id;
           
          // string s = i.ToString();
           
            return e.Get(Empid);
        }
    }
}
