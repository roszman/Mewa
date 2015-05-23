using System.Collections.Generic;
using Mewa.Cache.Domain;

namespace Mewa.Cache.Infrastructure.Repository
{
    public interface ICacheRepository
    {
        IEnumerable<CachedElement> GetElements();
    }
}