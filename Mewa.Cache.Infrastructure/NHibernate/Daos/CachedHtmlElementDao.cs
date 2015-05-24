using Mewa.Cache.Domain.Model;

namespace Mewa.Cache.Infrastructure.NHibernate.Daos
{
    public class CachedHtmlElementDao
    {
        public virtual long Id { get; set; }
        public virtual CachedHtmlElement CachedHtmlElement { get; set; }
    }
}
