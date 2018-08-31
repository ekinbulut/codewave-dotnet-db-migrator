using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.Data.Sql;
using System.ServiceProcess;

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

        [TestMethod]
        public void GetInstancesOfSQL()
        {

            ServiceController myService = new ServiceController();
            myService.ServiceName = "SQLBrowser";

            myService.MachineName = "localhost";
            string svcStatus = myService.Status.ToString();

            switch (svcStatus)
            {
                case "Stopped":
                    myService.Start();
                    break;

                default:
                    break;
            }



            SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
            DataTable table = instance.GetDataSources();
            //DisplayData(table);
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
