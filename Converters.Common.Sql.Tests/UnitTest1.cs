using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;

namespace Converters.Common.Sql.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Execute()
        {
            SampleRepository repo = new SampleRepository();

            var datatable = repo.ExecuteOrder1();

            


        }
    }


    interface ISampleRepository : ICommonRepository
    {

    }

    public class SampleRepository : CommonRepository, ISampleRepository
    {
        string conn = "Data Source=.;Integrated Security=True";

        public DataTable ExecuteOrder1()
        {
            return Execute(conn, "sp_databases");
        }
    }
}
