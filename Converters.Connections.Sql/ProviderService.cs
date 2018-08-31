using System.Collections.Generic;

namespace Converters.Connections.Sql
{
    using Common.Sql;
    using Contracts;
    using System.Data;

    public class ProviderService : CommonRepository,  IProviderService
    {

        public ProviderService() : base()
        {

        }

        public ProviderService(string connectionStr) : base(connectionStr)
        {

        }

        /// <summary>
        /// Gets the databases.
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <example>Data Source=##server_ip##;Integrated Security=True</example>
        /// <returns>String collection</returns>
        public ICollection<string> GetDatabases(string connection)
        {

            ICollection<string> dbs = new List<string>();

            string command = "sp_databases";
            var datatable  = Execute(connection, command);
            dbs            = FillCollection(datatable.Rows, "DATABASE_NAME");
            
            return dbs;
        }

        /// <summary>
        /// Gets the databases.
        /// </summary>
        /// <returns></returns>
        public ICollection<string> GetDatabases()
        {

            ICollection<string> dbs = new List<string>();

            string command = "sp_databases";
            var datatable  = Execute(ConnectionString, command);
            dbs            = FillCollection(datatable.Rows, "DATABASE_NAME");
            
            return dbs;
        }

        /// <summary>
        /// Gets the table list.
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <example>Data Source=##server_ip##;Initial Catalog=##database##;Integrated Security=True</example>
        /// <returns>String collection</returns>
        public ICollection<string> GetTableList(string connection)
        {
            ICollection<string> dbs = new List<string>();
            
            string command = "SELECT table_name as TABLE_NAME FROM INFORMATION_SCHEMA.Tables WHERE TABLE_TYPE = 'BASE TABLE'";
            var datatable  = Execute(connection, command);
            dbs            = FillCollection(datatable.Rows, "TABLE_NAME");

            return dbs;
        }

        /// <summary>
        /// Gets the table list.
        /// </summary>
        /// <returns></returns>
        public ICollection<string> GetTableList()
        {
            ICollection<string> dbs = new List<string>();
            
            string command = "SELECT table_name as TABLE_NAME FROM INFORMATION_SCHEMA.Tables WHERE TABLE_TYPE = 'BASE TABLE'";
            var datatable  = Execute(base.ConnectionString, command);
            dbs            = FillCollection(datatable.Rows, "TABLE_NAME");

            return dbs;
        }


        /// <summary>
        /// Fills the collection.
        /// </summary>
        /// <param name="rows">The rows.</param>
        /// <param name="columnName">Name of the column.</param>
        /// <returns></returns>
        private ICollection<string> FillCollection(DataRowCollection rows, string columnName)
        {
            ICollection<string> dbs = new List<string>();

            for (int i = 0; i < rows.Count; i++)
            {
                dbs.Add(rows[i][columnName].ToString());
            }

            return dbs;
        }
    }
}
