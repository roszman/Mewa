using System.Collections.Generic;
using System.Linq;
using Mewa.Cache.Domain;

namespace Mewa.Cache.WebServiceHost.Mappers
{
    //TODO change IEnumerable<CachedElement> to CachedElements class
    public class CachedElementsMapper : ICachedElementsMapper<IEnumerable<CachedElement>>
    {
        //TODO testy mapera
        public IEnumerable<ServiceContract.CachedElement> Map(
            IEnumerable<Domain.CachedElement> domainCachedElements)
        {
            return domainCachedElements.Select(cachedElement => 
                new ServiceContract.CachedElement(
                    cachedElement.TagName, 
                    cachedElement.TagAttributeValue, 
                    cachedElement.Url, 
                    cachedElement.TagValue
                    )).ToList();
        }
    }
}