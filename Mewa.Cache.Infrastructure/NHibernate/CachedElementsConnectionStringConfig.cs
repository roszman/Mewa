using Mewa.Cache.Infrastructure.Installer;

namespace Mewa.Cache.Infrastructure.NHibernate
{
    public class CachedElementsConnectionStringConfig : ICachedElementsConnectionStringConfig
    {
        public string ConnectionString { get; set; }
    }
}