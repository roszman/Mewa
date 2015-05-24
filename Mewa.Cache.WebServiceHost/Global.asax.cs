using System;
using System.Collections.Generic;
using Castle.Facilities.Logging;
using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Mewa.Cache.Domain.Model;
using Mewa.Cache.Domain.Repository;
using Mewa.Cache.Infrastructure.Installer;
using Mewa.Cache.Infrastructure.Repository;
using Mewa.Cache.WebServiceHost.Mappers;
using Mewa.Cache.WebServiceHost.ServiceContract;

namespace Mewa.Cache.WebServiceHost
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            //TODO create installer
            IWindsorContainer _container;
            _container = new WindsorContainer();
            _container.Install(Configuration.FromAppConfig());
            _container.AddFacility<WcfFacility>()
            .Register
            (
                Component.For<ICache>()
                    .ImplementedBy<ServiceContract.Cache>()
                    .AsWcfService(new DefaultServiceModel().Hosted()),
                //TODO move to infrastructure installer
                 Component.For<ICachedHtmlElementsRepository>().ImplementedBy<CachedHtmlElementsRepository>(),
                 Component.For<ICachedElementsMapper<IEnumerable<CachedHtmlElement>>>().ImplementedBy<CachedElementsMapper>()
            );
            _container.AddFacility<LoggingFacility>(m => m.UseNLog().WithConfig("NLog.config"));
            _container.Install(new NhibernateInstaller());
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