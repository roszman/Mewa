using System.ServiceProcess;
using Castle.Core.Logging;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Mewa.Cache.Infrastructure.Installer;
using NLog;

namespace Mewa.Cache.WindowsServiceHost
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            //TODO create installer
             var _container = new WindsorContainer();
            _container.Install(Configuration.FromAppConfig());
            _container.Install(new InfrastructureInstaller());
            _container.Register(
                Component.For<HtmlCacheService>()
                );
            var cacheService = _container.Resolve<HtmlCacheService>();
            
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
            { 
                cacheService
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
