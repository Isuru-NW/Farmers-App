using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Data.DBProviders
{
    public interface ISQLDBContext 
    {
        DbDataReader ExecuetReader(string sqlQuery, DbParameter[] parameters);
    }
}
