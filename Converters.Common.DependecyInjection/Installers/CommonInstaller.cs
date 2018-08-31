using System;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Converters.Common.DependecyInjection.Contracts;

namespace Converters.Common.DependecyInjection
{
    public abstract class CommonInstaller : ICommonInstaller
    {
        public abstract void Install(IWindsorContainer container, IConfigurationStore store);
        
    }
}
