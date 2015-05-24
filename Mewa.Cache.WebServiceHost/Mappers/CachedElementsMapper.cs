using System.Collections.Generic;
using System.Linq;
using Mewa.Cache.Domain;
using Mewa.Cache.Domain.Model;

namespace Mewa.Cache.WebServiceHost.Mappers
{
    //TODO change IEnumerable<CachedElement> to CachedElements class
    public class CachedElementsMapper : ICachedElementsMapper<IEnumerable<CachedHtmlElement>>
    {
        //TODO testy mapera
        public IEnumerable<ServiceContract.CachedElement> Map(
            IEnumerable<CachedHtmlElement> domainCachedElements)
        {
            return domainCachedElements.Select(cachedElement => 
                new ServiceContract.CachedElement
                //TODO what if some eleemntis null?
                (
                    cachedElement.HtmlElementAddress.Url, 
                    cachedElement.HtmlElementAddress.HtmlTag.Name, 
                    cachedElement.HtmlElementAddress.HtmlTag.Attribute.Name, 
                    cachedElement.HtmlElementAddress.HtmlTag.Attribute.Value, 
                    cachedElement.InnerHtml
                    )).ToList();
        }
    }
}