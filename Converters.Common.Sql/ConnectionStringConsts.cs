using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converters.Common.Sql
{
    public static class ConnectionStringConsts
    {
        public static string STRING_TEMPLATE        = "Data Source=##server_ip##;Integrated Security=True";
        public static string STRING_DB_TEMPLATE     = "Data Source=##server_ip##;Initial Catalog=##database##;Integrated Security=True";
        public static string STRING_DB_CRD_TEMPLATE = "Data Source=##server_ip##;Initial Catalog=##database##;User Id=##username##;Password=##passwd##";
    }
}
