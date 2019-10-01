using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EmployeeToolAdoNet;
using EmployeeToolEF;
using EmployeeToolModels;

namespace EmployeeTool
{
    class Program
    {
        static void Main(string[] args)
        {
            
           // Console.WriteLine(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);


            string s;
                Console.Write("Enter type: ");
            s = Console.ReadLine();

            object obj;
            switch (s)
            {
                case "ef":
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
                    // e.Id = 7;
                    // ef.Edit(e);

                    //   ef.AddEmployee(e);



                    break;

                case "ado":
                    //req.Id = Convert.ToInt32(id);
                     EmployeeOperation e3=new EmployeeOperation();
                    //   SalaryOperations s =new SalaryOperations();
                    //   SalaryModel s1=new SalaryModel();
                    //   s1.SalaryId = 101;
                    //   s1.SalaryPaidAmount = 234567;
                    //   s1.EmployeeId = 4;

                    //int n=s.AddSalary(s1);
                    //  // s.Edit(s1);
                    //   s.Delete("3");

                     EmployeeModel em = new EmployeeModel();
                     em.Name = "lalit";
                    //  em.Designation = "Developer";
                    //  e.AddEmployee(em);


                     e3.GetAll();

                    //  e.Get("2");
                    //  // em.Id;

                    //e.Edit(em);
                    //  e.Delete("2/*");*/
                    break;

                default:
                    Console.WriteLine("no suitable op");
                    break;


            }




            ////    EmployeeOperationEf e1=new EmployeeOperationEf();
            //EmployeeModel model=new EmployeeModel();
            //model.Name = "vijay";
            //model.Id = 13;
            ////  model.Doj = DateTime.Parse("11/23/2010");
            
            ////e1.AddEmployee(model);
            ////e1.Edit(model);
            //// e1.Delete("16");
            ////e1.Get("17");
            //e1.GetAll();






            


            Console.ReadLine();
        }
    }
}
