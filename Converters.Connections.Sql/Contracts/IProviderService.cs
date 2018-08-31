using Converters.Common.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converters.Connections.Sql.Contracts
{
    public interface IProviderService : ICommonRepository
    {
        ICollection<string> GetDatabases(string connection);

        ICollection<string> GetDatabases();

        ICollection<string> GetTableList(string connection);

        ICollection<string> GetTableList();
    }
}
