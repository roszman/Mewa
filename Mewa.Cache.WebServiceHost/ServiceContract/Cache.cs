using System.Collections.Generic;
using Castle.Core.Logging;
using Mewa.Cache.Domain.Repository;
using Mewa.Cache.WebServiceHost.Mappers;

namespace Mewa.Cache.WebServiceHost.ServiceContract
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Cache" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Cache.svc or Cache.svc.cs at the Solution Explorer and start debugging.
    public class Cache : ICache
    {
        private readonly ICachedHtmlElementsRepository _cachedHtmlElementsRepository;
        private readonly ICachedElementsMapper<IEnumerable<Domain.Model.CachedHtmlElement>> _cachedElementsMapper;

        public Cache(ICachedHtmlElementsRepository cachedHtmlElementsRepository, ICachedElementsMapper<IEnumerable<Domain.Model.CachedHtmlElement>> cachedElementsMapper)
        {
            _cachedHtmlElementsRepository = cachedHtmlElementsRepository;
            _cachedElementsMapper = cachedElementsMapper;
            Logger = NullLogger.Instance;
        }

        public ILogger Logger { get; set; }
        public IEnumerable<CachedElement> GetElements()
        {
            Logger.Info("GetCachedElements was called.");
            var elements = _cachedHtmlElementsRepository.GetCachedElements();
            return _cachedElementsMapper.Map(elements);

        }
    }
}
