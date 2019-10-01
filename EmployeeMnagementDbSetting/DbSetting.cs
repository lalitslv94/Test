using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMnagementDbSetting
{
    public class DbSetting
    {
        public string GetConnectionForSql()
        {

            return "Data Source=.;Initial Catalog=Learning;Integrated Security=True";
        }
    }
}
