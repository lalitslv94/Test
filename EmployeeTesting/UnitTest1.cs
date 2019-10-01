using System;
using System.Collections.Generic;
using EmployeeToolAdoNet;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeToolModels;

namespace EmployeeTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetEmployee()
        {
            EmployeeOperation e = new EmployeeOperation();




            EmployeeModel em = new EmployeeModel();
            em.Name = "lalit";
            em.Designation = "Developer";
            var id=e.AddEmployee(em);
           // var empRecAdd = e.Get(id.ToString());
           // Assert.IsNotNull(empRecAdd);
          //  Assert.AreEqual(empRecAdd.Name, em.Name);
            List<EmployeeModel> lst = e.GetAll();
            int i=lst.Count;
            Assert.AreEqual(i,id);



            //e.Get("2");
            // em.Id;
            e.AddEmployee(em);
           // e.Edit(em);
          //  e.Delete("2");
            
        }
    }
}
