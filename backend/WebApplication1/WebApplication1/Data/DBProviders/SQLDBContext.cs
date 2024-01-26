using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Data.DBProviders
{
    public class SQLDBContext : ISQLDBContext
    {
        private SqlTransaction _SqlTransaction;
        private SqlConnection _SqlConnection;      
        private SqlDataReader _SqlDataReader;

        public SQLDBContext(string connectionString)
        {
            _SqlConnection = new SqlConnection();
            _SqlConnection.ConnectionString = connectionString;
            _SqlConnection.Open();
        }

        public void Dispose()
        {
            if (_SqlDataReader != null && !_SqlDataReader.IsClosed)
                _SqlDataReader.Close();
            if (_SqlConnection != null && _SqlConnection.State == System.Data.ConnectionState.Open)
                _SqlConnection.Close();
            if (_SqlConnection != null)
                _SqlConnection.Dispose();
        }

        public DbDataReader ExecuetReader(string sqlQuery, DbParameter[] parameters)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _SqlConnection;
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.CommandText = sqlQuery;
            sqlCommand.Parameters.Clear();
            AddParameters(sqlCommand, parameters);
            if (_SqlTransaction != null)
                sqlCommand.Transaction = _SqlTransaction;
            _SqlDataReader = sqlCommand.ExecuteReader();
            return _SqlDataReader;
        }

        void AddParameters(SqlCommand sqlCommand, DbParameter[] parameters)
        {
            if (parameters != null)
                foreach (var parameter in parameters)
                    sqlCommand.Parameters.Add(parameter);
        }
    }
}
