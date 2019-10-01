using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeToolModels
{
   public class SalaryModel
    {
        private DateTime date;
        private double salaryPaidAmount;
        public int SalaryId { get; set; }
        private int _employeeId;

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public double SalaryPaidAmount
        {
            get { return salaryPaidAmount; }
            set { salaryPaidAmount = value; }
        }

        public int EmployeeId
        {
            get { return _employeeId; }
            set { _employeeId = value; }
        }
    }
}
