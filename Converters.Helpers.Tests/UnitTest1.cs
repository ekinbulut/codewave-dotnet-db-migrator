using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Converters.Helpers.Tests
{
    [TestClass]
    public class UnitTest1
    {

        QueueManager<Sample> queue;

        [TestInitialize]
        public void Initialize()
        {
            queue = QueueManager<Sample>.GetInstance;
        }


        [TestMethod]
        public void TestMethod1()
        {

            queue.Enqueue(new Sample() { Data = 1 });
            queue.Enqueue(new Sample() { Data = 2 });
            queue.Enqueue(new Sample() { Data = 3 });
            queue.Enqueue(new Sample() { Data = 4 });
            queue.Enqueue(new Sample() { Data = 5 });
            queue.Enqueue(new Sample() { Data = 6 });

            Assert.AreEqual(6,queue.Count);
           
            Sample data  = queue.Dequeue();

            Assert.AreEqual(1,data.Data);
        }
    }


    class Sample
    {
        public int Data { get; set; }
    }
}
