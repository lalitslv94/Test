using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeToolAdoNet;
using EmployeeToolModels;

namespace SalaryTesting
{
    [TestClass]
    public class Salary
    {
        [TestMethod]
        public void TestSalary()
        {
            SalaryOperations s1=new SalaryOperations();
            SalaryModel m1=new SalaryModel();
            m1.EmployeeId = 2;
            m1.SalaryPaidAmount = 234567;

            var addRec = s1.AddSalary(m1);
            Assert.AreEqual(addRec, m1.SalaryPaidAmount);
            var salrec = s1.Get(addRec.ToString());
            Assert.AreEqual(salrec, m1.EmployeeId);

             s1.Edit(m1);//check raju edit and delete wit no return type

            var get = s1.Get(m1.EmployeeId.ToString());
            Assert.AreEqual(m1.SalaryPaidAmount,get.SalaryPaidAmount);
           //chck count

            



            var addSal = s1.AddSalary(m1);
            Assert.AreEqual(addSal,m1.SalaryPaidAmount);
           // var salRec = s1.Get()
          //  Assert.IsNotNull(empRecAdd);
        }
    }
}
