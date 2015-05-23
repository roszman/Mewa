using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Mewa.Cache.Infrastructure.NHibernate.Maps;
using NHibernate;

namespace Mewa.Cache.Infrastructure.Installer
{
    public class NhibernateInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var config = BuildDatabaseConfiguration(container);

            container.Register(
                Component.For<ISessionFactory>()
                    .UsingFactoryMethod(_ => config.BuildSessionFactory()),
                Component.For<ISession>()
                    .UsingFactoryMethod(k => k.Resolve<ISessionFactory>().OpenSession()));
        }

        private FluentConfiguration BuildDatabaseConfiguration(IWindsorContainer container)
        {
            //TODO Fluent configuration
            //var connectionStringConfig = container.Resolve<IQuotationArchiveConnectionStringConfig>();

            var config = Fluently.Configure();
                //.Database(MsSqlConfiguration.MsSql2008.ConnectionString(connectionStringConfig.ConnectionString));

            config.ExposeConfiguration(c => c.SetProperty("adonet.batch_size", "50"));
            //.SetProperty("transaction.factory_class", "NHibernate.Transaction.AdoNetTransactionFactory"));

            //config.Mappings(m => m.FluentMappings.Conventions.Add<ColumnNameConvention>());
            config.Mappings(
                m =>
                    m.FluentMappings.AddFromAssembly(typeof(CachedElementMap).Assembly));
            return config;
        }
    }
}
