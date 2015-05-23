using System.Collections.Generic;
using Mewa.Cache.WebServiceHost.ServiceContract;

namespace Mewa.Cache.WebServiceHost.Mappers
{
    public interface ICachedElementsMapper<TDomainObject>
    {
        IEnumerable<CachedElement> Map(TDomainObject domainCachedElements);
    }
}