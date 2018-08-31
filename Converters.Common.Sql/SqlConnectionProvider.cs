using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converters.Common.Sql
{
    public class SqlConnectionProvider
    {
        SqlConnection _sql;

        public SqlConnection GetSqlConnectionInstance
        {
            get
            {
                return _sql == null ? _sql = new SqlConnection() : _sql;
            }
        }
    }
}
