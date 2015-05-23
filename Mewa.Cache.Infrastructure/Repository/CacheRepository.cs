using System.Collections.Generic;
using Mewa.Cache.Domain;
using Mewa.Cache.Domain.Repository;
using NHibernate;

namespace Mewa.Cache.Infrastructure.Repository
{
    public class CacheRepository : ICacheRepository
    {
        private readonly ISession _session;

        //TODO add logger
        public CacheRepository(ISession session)
        {
            _session = session;
        }

        public IEnumerable<CachedElement> GetElements()
        {
            //TODO error handling
            return _session.QueryOver<CachedElement>().List<CachedElement>();
        }
    }
}