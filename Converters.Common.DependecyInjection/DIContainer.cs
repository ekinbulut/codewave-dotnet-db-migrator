using Castle.Windsor;
using Converters.Common.DependecyInjection.Contracts;

namespace Converters.Common.DependecyInjection
{
    public class DIContainer : WindsorContainer , IDIContainer
    {
        static IDIContainer _container;

        public static IDIContainer ContainerInstance
        {
            get
            {
                return _container == null ? _container = new DIContainer() : _container;
            }
        }
    }
}
