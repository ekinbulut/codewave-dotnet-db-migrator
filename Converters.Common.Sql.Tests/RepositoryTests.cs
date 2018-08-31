using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;

namespace Converters.Common.Sql.Tests
{
    [TestClass]
    public class RepositoryTests
    {
        SampleRepository repo;

        [TestInitialize]
        public void Initialize()
        {
#if !DEBUG
            repo = new SampleRepository();

#else
            string conn = "Data Source=.;Integrated Security=True";

            repo = new SampleRepository(conn);
#endif
        }


        [TestMethod]
        public void Execute()
        {
            var datatable = repo.ExecuteOrder1();

            Assert.IsNotNull(datatable);
        }

        [TestMethod]
        public void ExecuteWithOnlyCommand()
        {

            var datatable = repo.Execute("sp_databases");

            Assert.IsNotNull(datatable);

        }
    }


    interface ISampleRepository : ICommonRepository
    {

    }

    public class SampleRepository : CommonRepository, ISampleRepository
    {
        string conn = "Data Source=.;Integrated Security=True";

        public SampleRepository() : base()
        {

        }

        public SampleRepository(string con) : base(con)
        {

        }

        public DataTable ExecuteOrder1()
        {
            return Execute(conn, "sp_databases");
        }
    }
}
