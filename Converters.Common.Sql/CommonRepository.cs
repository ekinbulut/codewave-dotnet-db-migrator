using System.Data;
using System.Data.SqlClient;

namespace Converters.Common.Sql
{
    public abstract class CommonRepository : ICommonRepository
    {
        protected readonly string ConnectionString;

        protected readonly SqlConnectionProvider Provider;

        public CommonRepository()
        {
            Provider = new SqlConnectionProvider();
        }

        public CommonRepository(string connectionString)
        {
            Provider = new SqlConnectionProvider();
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

            Provider.GetSqlConnectionInstance.ConnectionString = connection;

            SqlCommand executionCommand = new SqlCommand
            {
                Connection = Provider.GetSqlConnectionInstance,
                CommandType = CommandType.Text,
                CommandText = command
            };

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

            Provider.GetSqlConnectionInstance.ConnectionString = ConnectionString;

            SqlCommand executionCommand = new SqlCommand
            {
                Connection = Provider.GetSqlConnectionInstance,
                CommandType = CommandType.Text,
                CommandText = command
            };

            SqlDataAdapter adp = new SqlDataAdapter(executionCommand);

            adp.Fill(result);

            return result;

        }
    }
}
