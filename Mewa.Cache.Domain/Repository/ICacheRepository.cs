using System.Collections.Generic;

namespace Mewa.Cache.Domain.Repository
{
    public interface ICacheRepository
    {
        IEnumerable<CachedElement> GetElements();
    }
}