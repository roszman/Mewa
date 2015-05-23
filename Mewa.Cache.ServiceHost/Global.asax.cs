using System;
using System.Collections.Generic;
using Castle.Facilities.Logging;
using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Mewa.Cache.Domain.Repository;
using Mewa.Cache.Infrastructure.Repository;
using Mewa.Cache.ServiceHost.Mappers;

namespace Mewa.Cache.ServiceHost
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            //TODO create installer
            IWindsorContainer _container;
            _container = new WindsorContainer();
            _container.AddFacility<WcfFacility>()
            .Register
            (
                Component.For<ServiceContract.ICache>()
                    .ImplementedBy<ServiceContract.Cache>()
                    .AsWcfService(new DefaultServiceModel().Hosted()),
                    //TODO move to infrastructure installer
                 Component.For<ICacheRepository>().ImplementedBy<CacheRepository>(),
                 Component.For<ICachedElementsMapper<IEnumerable<Domain.CachedElement>>>().ImplementedBy<DomainCachedElementsMapper>()
            );
            _container.AddFacility<LoggingFacility>(m => m.UseNLog().WithConfig("NLog.config"));
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}