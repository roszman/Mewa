using System.Collections.Generic;
using Mewa.Cache.Domain;

namespace Mewa.Cache.ServiceHost.Mappers
{
    //TODO change IEnumerable<CachedElement> to CachedElements class
    public class DomainCachedElementsMapper : ICachedElementsMapper<IEnumerable<CachedElement>>
    {
        //TODO testy mapera
        public IEnumerable<ServiceContract.CachedElement> Map(
            IEnumerable<Domain.CachedElement> domainCachedElements)
        {
            var listOfServiceCOntractElements = new List<ServiceContract.CachedElement>();

            foreach (var cachedElement in domainCachedElements)
            {
                listOfServiceCOntractElements.Add(
                    new ServiceContract.CachedElement(
                        cachedElement.TagName, 
                        cachedElement.TagValue, 
                        cachedElement.Url, 
                        cachedElement.Value
                    ));
            }
            return listOfServiceCOntractElements;
        }
    }
}