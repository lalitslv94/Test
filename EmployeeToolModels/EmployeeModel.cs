using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeToolModels
{
   // [Table("Employee")]
    public class EmployeeModel
    {
       

        public int Id { get; set; }
        
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _designation;
        public string Designation
        {
            get { return _designation; }
            set { _designation = value; }
        }

        private DateTime DOB;

        public DateTime Dob
        {
            get { return DOB; }
            set { DOB = value; }
        }
        private DateTime DOJ;
        public DateTime Doj
        {
            get { return DOJ; }
            set { DOJ = value; }
        }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<salary> salaries { get; set; }


    }
}
