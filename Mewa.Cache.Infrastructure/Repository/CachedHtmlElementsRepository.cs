using System;
using System.Collections.Generic;
using System.Linq;
using Castle.MicroKernel.ModelBuilder.Descriptors;
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

            if (cachedHtmlElement != null)
            {
                UpdateCachedHtmlElement(cachedHtmlElement);
            }
        }

        public void Add(CachedHtmlElement cachedHtmlElement)
        {
            //TODO error handling and logging
            _session.Save(cachedHtmlElement);
            _session.Flush();
        }

        public void Delete(long id)
        {
            //TODO error logging
            var cachedHtmlElement =_session.QueryOver<CachedHtmlElement>()
                .Where(che => che.Id == id).List().FirstOrDefault();
            _session.Delete(cachedHtmlElement);
            _session.Flush();
        }

        public IEnumerable<CachedHtmlElement> GetAllHtmlElements()
        {
            //TODO error handling 
            return _session
                .QueryOver<CachedHtmlElement>()
                .List();

        }

        public CachedHtmlElement GetCachedElementById(long id)
        {
            //todo error logging
            return _session
                .QueryOver<CachedHtmlElement>()
                .Where(che => che.Id == id)
                .List()
                .FirstOrDefault();
        }

        public IEnumerable<CachedHtmlElement> GetCachedElements()
        {
            //TODO error handling
            var cachedHtmlElements =  _session.
                QueryOver<CachedHtmlElement>()
                .Where(cachedHtmlElement => 
                    cachedHtmlElement.LastRefreshDate != null)
                .List<CachedHtmlElement>();
            return cachedHtmlElements;
        }

        private void UpdateCachedHtmlElement(CachedHtmlElement cachedHtmlElement)
        {
            cachedHtmlElement.LastRefreshDate = DateTime.Now;
            cachedHtmlElement.InnerHtml = cachedHtmlElement.InnerHtml;

            _session.SaveOrUpdate(cachedHtmlElement);
            _session.Flush();
        }
    }
}