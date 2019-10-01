using System.Data;
using System.Data.Common;

namespace DataAccessLayer
{
    public abstract class DataAccess
    {
        protected string ConnectionString;

        protected DbConnection DbConnection;

        protected bool Connected;

        protected DataAccess()
        {
            Connected = false;
        }

        protected abstract void Connect();

        protected abstract void Close();

        public abstract IDataReader ReadData(DbCommand command);
        public abstract DataSet ExecuteDataSetWithoutTimeout(DbCommand command);
        public abstract IDataReader ReadDataUsingStoredProcedures(DbCommand command);
        public abstract void ExecuteCommandUsingStoredProceduresNew(DbCommand command);
        public abstract void ExecuteCommand(DbCommand command);
        public abstract DataTable ExecuteDataTable(DbCommand command);
        public abstract DataSet ExecuteDataSet(DbCommand command);
        public abstract void ExecuteCommandUsingStoredProcedures(DbCommand command);
        public abstract int ExecuteInlineSqlQuery(DbCommand command);
        public abstract int ExecuteInlineSqlQueryNew(DbCommand command);
        public abstract DataSet GetDatasetNySp(DbCommand command);
        public abstract DataSet ExecuteDataSetForSqlQuery(DbCommand command);
        public abstract DataSet ExecuteDataSetForSqlQueryNew(DbCommand command);
        public abstract void ExecuteInlineSqlQueryForUpdate(DbCommand command);

        public abstract void ExecuteInlineSqlQueryForUpdateNew(DbCommand command);

        public abstract DbCommand Command(string name);

        public abstract DbParameter Parameter(string nama, object value);

        public abstract bool IsConnected { get; }

        public DbConnection Connection
        {
            get { return DbConnection; }
        }
        public abstract int ExecuteNonQuery(DbCommand command);
        public abstract DbTransaction BeginTransaction();

        public abstract DataSet GetDatasetNewSpWithoutTimeout(DbCommand command);
    }
}