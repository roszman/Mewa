using System.Collections.Generic;
using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Mewa.Cache.Domain.Model;
using Mewa.Cache.WebUI.Admin.Mappers;

namespace Mewa.Cache.WebUI.Admin.Castle.Installers
{
    public class WebUiAdminInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                                .BasedOn<IController>()
                                .LifestyleTransient());
            container.Register(
                Component.For<IViewModelMapper<CachedHtmlElement>>()
                    .ImplementedBy<CachedElementToViewModelMapper>()
                );
        }
    }
}