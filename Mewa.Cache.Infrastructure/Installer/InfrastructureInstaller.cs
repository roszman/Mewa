using Castle.Facilities.Logging;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Mewa.Cache.Domain.Repository;
using Mewa.Cache.Infrastructure.Repository;

namespace Mewa.Cache.Infrastructure.Installer
{
    public class InfrastructureInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Install(new NhibernateInstaller());
            container.Register(
                Component.For<ICachedHtmlElementsRepository>().ImplementedBy<CachedHtmlElementsRepository>() 
                );
            container.AddFacility<LoggingFacility>(m => m.UseNLog().WithConfig("NLog.config"));
        }
    }
}
