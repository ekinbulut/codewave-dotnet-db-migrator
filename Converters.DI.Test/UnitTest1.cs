using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Converters.Common.DependecyInjection;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Converters.DI.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            DIContainer.ContainerInstance.Register(Component.For<ComponentSample>().ImplementedBy<ComponentSample>());

            var sample = DIContainer.ContainerInstance.Resolve<ComponentSample>();

            Assert.AreEqual(typeof(ComponentSample), sample.GetType());
        }

        [TestMethod]
        public void RegisterComponentViaInstaller()
        {

            DIContainer.ContainerInstance.Install(new ComponentInstaller());

            var sample = DIContainer.ContainerInstance.Resolve<ComponentSample>();

            Assert.AreEqual(typeof(ComponentSample), sample.GetType());

        }

    }

    public class ComponentSample
    {


    }

    public class ComponentInstaller : CommonInstaller
    {

        public override void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<ComponentSample>().ImplementedBy<ComponentSample>());
        }
    }
}
