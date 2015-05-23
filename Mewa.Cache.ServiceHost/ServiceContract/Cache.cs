using System.Collections.Generic;
using Mewa.Cache.Infrastructure.Repository;
using Mewa.Cache.ServiceHost.Mappers;

namespace Mewa.Cache.ServiceHost.ServiceContract
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Cache" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Cache.svc or Cache.svc.cs at the Solution Explorer and start debugging.
    public class Cache : ICache
    {
        private readonly ICacheRepository _cacheRepository;
        private readonly ICachedElementsMapper<IEnumerable<Domain.CachedElement>> _cachedElementsMapper;

        public Cache(ICacheRepository cacheRepository, ICachedElementsMapper<IEnumerable<Domain.CachedElement>> cachedElementsMapper)
        {
            _cacheRepository = cacheRepository;
            _cachedElementsMapper = cachedElementsMapper;
        }

        public IEnumerable<CachedElement> GetElements()
        {

            var elements = _cacheRepository.GetElements();
            return _cachedElementsMapper.Map(elements);

        }
    }
}
