using System.Data.SqlClient;

namespace Converters.Common.Sql
{
    public class SqlConnectionProvider
    {
        SqlConnection _sql;

        public SqlConnection GetSqlConnectionInstance => _sql ?? (_sql = new SqlConnection());
    }
}
