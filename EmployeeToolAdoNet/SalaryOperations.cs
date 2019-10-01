using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using EmployeeMnagementDbSetting;
using EmployeeToolInterfaces;
using EmployeeToolModels;

namespace EmployeeToolAdoNet
{
    public class SalaryOperations:ISalaryCrud
    {
       
            DbSetting con = new DbSetting();
            public int AddSalary(SalaryModel salaryModel)
            {
                double salary = salaryModel.SalaryPaidAmount;
                DateTime salaryDate = salaryModel.Date;
                int empId = salaryModel.EmployeeId;
        // actorName = actor.ActorName;
        var InsertQuery = "INSERT INTO salary(salary_amount_paid,Fk_EmployeeId ) " +
                                 "VALUES (@salary,@empId) ;SELECT @@IDENTITY AS 'ID'; ";

                SqlDataAccess d = new SqlDataAccess(con.GetConnectionForSql());

                d.Connection.Open();
                var cmd = d.Command(InsertQuery);
                //  AddObjectParameter(d, cmd, "actorId", actorId);
                AddObjectParameter(d, cmd, "salary", salary);
                AddObjectParameter(d, cmd, "empId", empId);

                int i = d.ExecuteInlineSqlQueryNew(cmd);
           // d.Connection.Close();
            return i;
           

            }

        public void Edit(SalaryModel salaryModel)
        {
            double amount = salaryModel.SalaryPaidAmount;
            int empId = salaryModel.EmployeeId;
            // actorName = actor.ActorName;
            var InsertQuery = "UPDATE salary" +
 " SET salary_amount_paid = @amount" +
 " WHERE Fk_EmployeeId = @empId ";

            SqlDataAccess d = new SqlDataAccess(con.GetConnectionForSql());

            d.Connection.Open();
            var cmd = d.Command(InsertQuery);
            //  AddObjectParameter(d, cmd, "actorId", actorId);
            AddObjectParameter(d, cmd, "amount", amount);
            AddObjectParameter(d, cmd, "empId", empId);

            d.ExecuteInlineSqlQueryForUpdate(cmd);
        }

        public void Delete(string id)
            {

                var DelQuery = "DELETE FROM salary WHERE Fk_EmployeeId=@id ";

                SqlDataAccess d = new SqlDataAccess(con.GetConnectionForSql());

                d.Connection.Open();
                var cmd = d.Command(DelQuery);

                AddObjectParameter(d, cmd, "Id", Convert.ToInt32(id));

                int count = d.ExecuteInlineSqlQuery(cmd);
            }

        public List<SalaryModel> GetAll()
        {
            List<SalaryModel> lst = new List<SalaryModel>();
            string getAllEmp = "select * from salary";

            SqlDataAccess d = new SqlDataAccess(con.GetConnectionForSql());

            d.Connection.Open();
            var cmd = d.Command(getAllEmp);
            DataSet ds = d.ExecuteDataSetForSqlQueryNew(cmd);

            var table = ds.Tables[0];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                var id = table.Rows[i]["Fk_EmployeeId"];
                SalaryModel e = new SalaryModel();
                e.EmployeeId = Convert.ToInt32(id);
                var amount = table.Rows[i]["salary_amount_paid"];
                e.SalaryPaidAmount = Convert.ToDouble(amount);
                lst.Add(e);

                Console.WriteLine(id);
                Console.WriteLine(amount);

            }
            //    return lst;
            return lst;



        }

        public SalaryModel Get(string id)
            {
                SalaryModel e = null;
                string getAllEmp = "select * from salary where Fk_EmployeeId=@id";

                SqlDataAccess d = new SqlDataAccess(con.GetConnectionForSql());

                d.Connection.Open();
                var cmd = d.Command(getAllEmp);
                AddObjectParameter(d, cmd, "Id", Convert.ToInt32(id));
                IDataReader d1 = d.ReadData(cmd);
                {

                if (d1.Read())
                {
                    e = new SalaryModel();
                    var empid = d1["Fk_EmployeeId"];
                    e.EmployeeId = Convert.ToInt32(empid);
                    var salary = d1["salary_amount_paid"];
                    e.SalaryPaidAmount = Convert.ToDouble(salary);
                }

              //  e.EmployeeId = ;
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

