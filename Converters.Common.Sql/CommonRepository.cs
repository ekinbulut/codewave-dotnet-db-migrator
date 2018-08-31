using System.Data;
using System.Data.SqlClient;

namespace Converters.Common.Sql
{
    public abstract class CommonRepository : ICommonRepository
    {
        protected string ConnectionString;

        protected SqlConnectionProvider provider;

        public CommonRepository()
        {
            provider = new SqlConnectionProvider();
        }

        public CommonRepository(string connectionString)
        {
            provider = new SqlConnectionProvider();
            ConnectionString = connectionString;
        }

        /// <summary>
        /// Executes the specified connection.
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        public virtual DataTable Execute(string connection, string command)
        {
            DataTable result = new DataTable();

            provider.GetSqlConnectionInstance.ConnectionString = connection;

            SqlCommand executionCommand  = new SqlCommand();
            executionCommand.Connection  = provider.GetSqlConnectionInstance;
            executionCommand.CommandType = System.Data.CommandType.Text;
            executionCommand.CommandText = command;

            SqlDataAdapter adp = new SqlDataAdapter(executionCommand);

            adp.Fill(result);

            return result;

        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        public virtual DataTable Execute(string command)
        {
            DataTable result = new DataTable();

            provider.GetSqlConnectionInstance.ConnectionString = ConnectionString;

            SqlCommand executionCommand  = new SqlCommand();
            executionCommand.Connection  = provider.GetSqlConnectionInstance;
            executionCommand.CommandType = System.Data.CommandType.Text;
            executionCommand.CommandText = command;

            SqlDataAdapter adp = new SqlDataAdapter(executionCommand);

            adp.Fill(result);

            return result;

        }
    }
}
