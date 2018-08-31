using System.Data;

namespace Converters.Common.Sql
{
    public interface ICommonRepository
    {
        DataTable Execute(string connection, string command);

        DataTable Execute(string command);
    }
}