using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;


namespace DataAccessLayer
{
    public class SqlDataAccess : DataAccess
    {
        public SqlDataAccess(string connectionString)
        {
            if (connectionString == null) throw new ArgumentException("connectionString cannot be null");

            ConnectionString = connectionString;
            DbConnection = new SqlConnection(ConnectionString);
        }

        protected override void Connect()
        {
            try
            {
                if (DbConnection.State != ConnectionState.Open)
                    DbConnection.Open();
            }
            catch (Exception ex)
            {
                //Logger.Instance.Log(LogLevel.INFO, string.Format("Connection string --->{0}", ConnectionString));
                //Logger.Instance.Log(LogLevel.ERROR, ex);
            }
        }

        protected override void Close()
        {
            DbConnection.Close();
            DbConnection.Dispose();
        }

        public override IDataReader ReadData(DbCommand command)
        {
            SetCommandTimeout(command);
            Connect();
            command.Connection = Connection;
            command.CommandType = CommandType.Text;
            var reader = command.ExecuteReader();
            //Close();
            return reader;
        }

        public override IDataReader ReadDataUsingStoredProcedures(DbCommand command)
        {
            SetCommandTimeout(command);
            Connect();
            command.Connection = Connection;
            command.CommandType = CommandType.StoredProcedure;
            var reader = command.ExecuteReader();
            Close();
            return reader;
        }

        public override void ExecuteCommand(DbCommand command)
        {
            SetCommandTimeout(command);
            Connect();
            command.Connection = Connection;
            command.CommandType = CommandType.Text;
            command.ExecuteNonQuery();
            Close();
        }

        public override void ExecuteCommandUsingStoredProceduresNew(DbCommand command)
        {
            SetCommandTimeout(command);
            command.Connection = Connection;
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
        }

       

        public override void ExecuteCommandUsingStoredProcedures(DbCommand command)
        {
            SetCommandTimeout(command);
            Connect();
            command.Connection = Connection;
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            Close();
        }
        public override DataSet ExecuteDataSetForSqlQuery(DbCommand command)
        {
            SetCommandTimeout(command);
            Connect();
            command.Connection = Connection;
            command.CommandType = CommandType.Text;
            var dataAdapter = new SqlDataAdapter { SelectCommand = (SqlCommand)command };
            var dbSet = new DataSet();
            dataAdapter.Fill(dbSet);
            Close();
            return dbSet;
        }

        public override DataTable ExecuteDataTable(DbCommand command)
        {
            SetCommandTimeout(command);
            Connect();
            command.Connection = Connection;
            command.CommandType = CommandType.StoredProcedure;
            var dataAdapter = new SqlDataAdapter { SelectCommand = (SqlCommand)command };
            var dTable = new DataTable();
            dataAdapter.Fill(dTable);
            Close();
            return dTable;
        }

        public override DbCommand Command(string name)
        {
            var command = new SqlCommand(name);
            return command;
        }

        public override DbParameter Parameter(string name, object value)
        {
            return new SqlParameter(name, value);
        }

        public override bool IsConnected
        {
            get { return Connected; }
        }

        public override DataSet ExecuteDataSetWithoutTimeout(DbCommand command)
        {
            Connect();
            command.Connection = Connection;
            command.CommandType = CommandType.StoredProcedure;
            var dataAdapter = new SqlDataAdapter { SelectCommand = (SqlCommand)command };
            var dbSet = new DataSet();
            dataAdapter.Fill(dbSet);
            Close();
            return dbSet;
        }

        public override DataSet GetDatasetNySp(DbCommand command)
        {
            SetCommandTimeout(command);
            command.Connection = Connection;
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            var dataAdapter = new SqlDataAdapter { SelectCommand = (SqlCommand)command };
            var dbSet = new DataSet();
            dataAdapter.Fill(dbSet);

            return dbSet;
        }

        public override DataSet GetDatasetNewSpWithoutTimeout(DbCommand command)
        {
            command.Connection = Connection;
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            var dataAdapter = new SqlDataAdapter { SelectCommand = (SqlCommand)command };
            var dbSet = new DataSet();
            dataAdapter.Fill(dbSet);

            return dbSet;
        }

        public override DataSet ExecuteDataSet(DbCommand command)
        {
            SetCommandTimeout(command);
            Connect();
            command.Connection = Connection;
            command.CommandType = CommandType.StoredProcedure;
            var dataAdapter = new SqlDataAdapter { SelectCommand = (SqlCommand)command };
            var dbSet = new DataSet();
            dataAdapter.Fill(dbSet);
            Close();
            return dbSet;
        }

        public override DataSet ExecuteDataSetForSqlQueryNew(DbCommand command)
        {
            SetCommandTimeout(command);
            command.Connection = Connection;
            command.CommandType = CommandType.Text;
            var dataAdapter = new SqlDataAdapter { SelectCommand = (SqlCommand)command };
            var dbSet = new DataSet();
            dataAdapter.Fill(dbSet);
            return dbSet;
        }

        public override int ExecuteNonQuery(DbCommand command)
        {
            SetCommandTimeout(command);
            Connect();
            command.Connection = Connection;
            command.CommandType = CommandType.StoredProcedure;
            var res = command.ExecuteNonQuery();
            Close();
            return res;
        }

        public override int ExecuteInlineSqlQuery(DbCommand command)
        {
            SetCommandTimeout(command);
            Connect();
            command.Connection = Connection;
            command.CommandType = CommandType.Text;
            var valueObj = command.ExecuteScalar();
            Close();
            return Convert.ToInt32(valueObj);
        }

        public override int ExecuteInlineSqlQueryNew(DbCommand command)
        {
            command.Connection = Connection;
            SetCommandTimeout(command);
            command.CommandType = CommandType.Text;
            var valueObj = command.ExecuteScalar();
            if (!string.IsNullOrEmpty(Convert.ToString(valueObj)))
            {
                return Convert.ToInt32(valueObj);
            }
            return 0;
        }

        public override void ExecuteInlineSqlQueryForUpdate(DbCommand command)
        {
            Connect();
            SetCommandTimeout(command);
            command.Connection = Connection;
            command.CommandType = CommandType.Text;
            command.ExecuteNonQuery();
            Close();
        }
        public override void ExecuteInlineSqlQueryForUpdateNew(DbCommand command)
        {
            SetCommandTimeout(command);
            command.Connection = Connection;
            command.CommandType = CommandType.Text;
            command.ExecuteNonQuery();
        }
        public override DbTransaction BeginTransaction()
        {
            return DbConnection.BeginTransaction();
        }

        private void SetCommandTimeout(DbCommand command)
        {
            command.CommandTimeout = 250;
        }
    }
}
