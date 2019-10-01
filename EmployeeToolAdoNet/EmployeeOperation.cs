using EmployeeToolInterfaces;
using EmployeeToolModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using EmployeeManagement.Utils;
using Microsoft.SqlServer.Server;
using EmployeeMnagementDbSetting;

namespace EmployeeToolAdoNet
{
    public class EmployeeOperation:IEmployeeCrud
    {
         DbSetting con = new DbSetting();
        public int AddEmployee(EmployeeModel employeeModel)
        {
            string Name = employeeModel.Name ;
           // actorName = actor.ActorName;
            var InsertQuery = "INSERT INTO Employee(Name ) " +
                             "VALUES (@Name) ;SELECT @@IDENTITY AS 'ID';";

            SqlDataAccess d = new SqlDataAccess(con.GetConnectionForSql());

            d.Connection.Open();
            var cmd = d.Command(InsertQuery);
          //  AddObjectParameter(d, cmd, "actorId", actorId);
            AddObjectParameter(d, cmd, "Name", Name);

          int i=  d.ExecuteInlineSqlQueryNew(cmd);
            return i;

        }

        public void Edit(EmployeeModel employeeModel)
        {
            string Name = employeeModel.Name;
            int id = employeeModel.Id;
          //  string Desig = employeeModel.Designation;
            // actorName = actor.ActorName;
            var InsertQuery = "UPDATE employee"+
 " SET Name = @Name" +
 " WHERE Id = @Id; ";

            SqlDataAccess d = new SqlDataAccess(con.GetConnectionForSql());

            d.Connection.Open();
            var cmd = d.Command(InsertQuery);
            //  AddObjectParameter(d, cmd, "actorId", actorId);
            AddObjectParameter(d, cmd, "Name", Name);
            AddObjectParameter(d, cmd, "Id", id);

            d.ExecuteInlineSqlQueryForUpdate(cmd);
        }

        public void Delete(string id)
        {
            
            var DelQuery = "DELETE FROM Employee WHERE Id=@id ";

            SqlDataAccess d = new SqlDataAccess(con.GetConnectionForSql());

            d.Connection.Open();
            var cmd = d.Command(DelQuery);
          
            AddObjectParameter(d, cmd, "Id", Convert.ToInt32(id));

           int count= d.ExecuteInlineSqlQuery(cmd);
        }

        public List<EmployeeModel> GetAll()
        {
            List<EmployeeModel> lst=new List<EmployeeModel>();
            string getAllEmp = "select * from employee";
            
            SqlDataAccess d = new SqlDataAccess(con.GetConnectionForSql());

            d.Connection.Open();
            var cmd=d.Command(getAllEmp);
            DataSet ds=d.ExecuteDataSetForSqlQueryNew(cmd);
         
            var table = ds.Tables[0];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                var id = table.Rows[i]["Id"];
                EmployeeModel e=new EmployeeModel();
                e.Id = Convert.ToInt32(id);
                var Name = table.Rows[i]["Name"];
                e.Name = Convert.ToString(Name);
                lst.Add(e);
              
                Console.WriteLine(id);
                Console.WriteLine(Name);
                
            }
            return lst;



        }

        public EmployeeModel Get(string id)
        {
            EmployeeRequestObject req=new EmployeeRequestObject();

            EmployeeModel e = null;

            int EmpId = Convert.ToInt32(id);
            int EmpID = EmpId;
            string getAllEmp = "select * from employee where Id=@id";

            SqlDataAccess d = new SqlDataAccess(con.GetConnectionForSql());

            d.Connection.Open();
            var cmd = d.Command(getAllEmp);
           AddObjectParameter(d, cmd, "Id", EmpID);
            IDataReader d1 = d.ReadData(cmd);
            {

                if (d1.Read())
                {
                     e = new EmployeeModel();
                    var empid = d1["Id"];
                    e.Id = Convert.ToInt32(empid);
                    //var empName = d1["Name"];
                    //e.Name = Convert.ToString(empName);
                }
                
                //  e.Id = ddd.;
            }
            return e;
            d.Connection.Close();


        }

        public static void AddObjectParameter(DataAccess access, DbCommand command, string name, object value)
        {
            command.CreateParameter();
            command.Parameters.Add(access.Parameter("@" + name, value));
        }
    }
}
