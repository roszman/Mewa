using System.Collections.Generic;
using System.Linq;
using Mewa.Cache.Domain;
using Mewa.Cache.Domain.Model;
using Mewa.Cache.Domain.Repository;
using Mewa.Cache.Infrastructure.NHibernate.Daos;
using NHibernate;

namespace Mewa.Cache.Infrastructure.Repository
{
    public class CachedHtmlElementsRepository : ICachedHtmlElementsRepository
    {
        private readonly ISession _session;

        //TODO add logger
        public CachedHtmlElementsRepository(ISession session)
        {
            _session = session;
        }

        public void Save(CachedHtmlElement cachedHtmlElement)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<CachedHtmlElement> GetCachedElements()
        {
            //TODO error handling
            var cachedHtmlElementDaos =  _session.
                QueryOver<CachedHtmlElementDao>()
                .Where(cachedHtmlElementDao => 
                    cachedHtmlElementDao.CachedHtmlElement.LastRefreshDate != null)
                .List<CachedHtmlElementDao>();
            return cachedHtmlElementDaos.Select(che => che.CachedHtmlElement);
        }
    }
}