using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converters.Common.Sql
{
    public abstract class CommonRepository : ICommonRepository
    {

        protected SqlConnectionProvider provider;

        public CommonRepository()
        {
            provider = new SqlConnectionProvider();
        }

        public DataTable Execute(string connection, string command)
        {
            DataTable result = new DataTable();

            provider.GetSqlConnectionInstance.ConnectionString = connection;

            SqlCommand executionCommand = new SqlCommand();
            executionCommand.Connection = provider.GetSqlConnectionInstance;
            executionCommand.CommandType = System.Data.CommandType.Text;
            executionCommand.CommandText = command;

            SqlDataAdapter adp = new SqlDataAdapter(executionCommand);

            adp.Fill(result);

            return result;

        }
    }
}
