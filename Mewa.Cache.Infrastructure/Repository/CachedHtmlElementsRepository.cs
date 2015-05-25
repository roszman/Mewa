using System;
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

        public void Update(CachedHtmlElement cachedHtmlElement)
        {
            //TODO error/null handling and logging
            var cachedHtmlElementDao = GetCachedHtmlElementDao(
                cachedHtmlElement.HtmlElementAddress.Url,
                cachedHtmlElement.HtmlElementAddress.HtmlTag.Name,
                cachedHtmlElement.HtmlElementAddress.HtmlTag.Attribute.Name,
                cachedHtmlElement.HtmlElementAddress.HtmlTag.Attribute.Value);

            if (cachedHtmlElementDao != null)
            {
                UpdateCachedHtmlElement(cachedHtmlElement, cachedHtmlElementDao);
            }
        }

        public void Add(CachedHtmlElement cachedHtmlElement)
        {
            //TODO error handling and logging
            _session.Save(new CachedHtmlElementDao
            {
                CachedHtmlElement = cachedHtmlElement
            });
            _session.Flush();
        }

        public IEnumerable<CachedHtmlElement> GetAllHtmlElements()
        {
            //TODO error handling 
            return _session
                .QueryOver<CachedHtmlElementDao>()
                .List()
                .Select(ae => ae.CachedHtmlElement);

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

        private void UpdateCachedHtmlElement(CachedHtmlElement cachedHtmlElement, CachedHtmlElementDao cachedHtmlElementDao)
        {
            cachedHtmlElementDao.CachedHtmlElement.LastRefreshDate = DateTime.Now;
            cachedHtmlElementDao.CachedHtmlElement.InnerHtml = cachedHtmlElement.InnerHtml;

            _session.SaveOrUpdate(cachedHtmlElementDao);
            _session.Flush();
        }

        private CachedHtmlElementDao GetCachedHtmlElementDao(string url, string htmlTagName, string htmlTagAttributeName, string htmlTagAttributeValue)
        {
            return _session.QueryOver<CachedHtmlElementDao>()
                .Where(
                    chdao => chdao.CachedHtmlElement.HtmlElementAddress.Url == url
                             && chdao.CachedHtmlElement.HtmlElementAddress.HtmlTag.Name == htmlTagName
                             && chdao.CachedHtmlElement.HtmlElementAddress.HtmlTag.Attribute.Name == htmlTagAttributeName
                             && chdao.CachedHtmlElement.HtmlElementAddress.HtmlTag.Attribute.Value == htmlTagAttributeValue
                ).List<CachedHtmlElementDao>().FirstOrDefault();
        }
    }
}