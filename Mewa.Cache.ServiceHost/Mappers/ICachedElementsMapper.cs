using System.Collections.Generic;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Mewa.Cache.ServiceHost.ServiceContract;

namespace Mewa.Cache.ServiceHost.Mappers
{
    public interface ICachedElementsMapper<TDomainObject>
    {
        IEnumerable<CachedElement> Map(TDomainObject domainCachedElements);
    }
}