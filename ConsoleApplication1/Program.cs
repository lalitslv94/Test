using EmployeeToolEF;
using EmployeeToolModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeOperationEf ef = new EmployeeOperationEf();
            EmployeeRequestObject req = new EmployeeRequestObject();
            string id = "17";
            // ef.GetAll();
            string Id = "4";
            ef.GetAll();
            ef.Get(id);
            EmployeeRequestObject e11 = new EmployeeRequestObject();
            e11.Id = 8;
            ef.Delete(Id);


            EmployeeModel e = new EmployeeModel();
            e.Name = "dyu";
        }
    }
}
