using EmployeeToolModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace EFModels
{

    public partial class EmpManagement : DbContext
    {
        public EmpManagement()
            : base("name=EmpMgmt")
        {
        }

        public virtual DbSet<EmployeeModel> Employees { get; set; }
        public virtual DbSet<SalaryModel> salaries { get; set; }


    }
}
