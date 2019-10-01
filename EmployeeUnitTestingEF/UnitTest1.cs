using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeToolEF;

using EmployeeToolModels;

namespace EmployeeUnitTestingEF
{
    [TestClass]
    public class UnitTest1
    {


        EmployeeOperationEf e = new EmployeeOperationEf();
       
        
        EmployeeModel emp = new EmployeeModel();
        



         List<EmployeeModel> lst = null;

        //[TestMethod]
        //public EmployeeModel GetSingle()
        //{
        //    emp.Name = "dyu";
        //    EmployeeModel emply = e.Get("7");

        //    Assert.AreEqual(emply.Name, emp.Name);
        //    return emply;
        //}


        //[TestMethod]
        //public void InsertRecord()
        //{
        //   EmployeeModel e3= GetSingle();
            
        //    emp.Name = "dyu";
        //  int n=  e.AddEmployee(emp);
        //   Assert.AreEqual(e3.Name,emp.Name);  
        //}

        

        //[TestMethod]
        //public void DeleteRecords()
        //{
        //    string s = "8";
          
        //    e.Delete(s);
        //}

        //[TestMethod]
        //public void fetchRecords()
        //{
        //    lst = e.GetAll();
        //    Assert.AreEqual(lst.Count,14);
        //}

        

        [TestMethod]
        public void GetALl()
        {
        }
    }
}
