﻿using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Mewa.Cache.ServiceHost.Installers
{
    public class CacheServiceHostInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            throw new System.NotImplementedException();
        }
    }
}