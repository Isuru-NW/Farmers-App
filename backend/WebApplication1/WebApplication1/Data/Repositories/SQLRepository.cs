using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Data.Repositories
{
    public class SQLRepository
    {
        public DbParameter StringParameter(string name, string value = null, ParameterDirection direction = ParameterDirection.Input, int size = 1)
        {
            var param = CreateParameter(name, DbType.String, value, direction, size);
            return param;
        }

        public DbParameter CreateParameter(string name, DbType dbType, object value = null, ParameterDirection direction = ParameterDirection.Input, int size = 1)
        {
            var param = new SqlParameter { DbType = dbType, ParameterName = name, Value = value ?? DBNull.Value, Direction = direction };
            if (size > 1)
                param.Size = size;
            return param;
        }

        public DbParameter IntParameter(string name, int? value = null, ParameterDirection direction = ParameterDirection.Input)
        {
            var param = CreateParameter(name, DbType.Int32, value, direction);
            return param;
        }

        public DbParameter DecimalParameter(string name, decimal? value = null, ParameterDirection direction = ParameterDirection.Input)
        {
            var param = CreateParameter(name, DbType.Decimal, value, direction);
            return param;
        }


    }
}
