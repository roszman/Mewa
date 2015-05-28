using System.Collections.Generic;
using System.Linq;
using Mewa.Cache.Domain.Model;
using Mewa.Cache.WebUI.Admin.Models;

namespace Mewa.Cache.WebUI.Admin.Mappers
{
    public class CachedElementToViewModelMapper : IViewModelMapper<CachedHtmlElement>
    {
        public HtmlElelmentToCache Map(CachedHtmlElement cachedHtmlElement)
        {
            //TODO error handling, check for nulls
            return new HtmlElelmentToCache()
            {
                Id = cachedHtmlElement.Id,
                Url = cachedHtmlElement.HtmlElementAddress.Url, 
                TagName = cachedHtmlElement.HtmlElementAddress.HtmlTag.Name, 
                TagAttributeName = cachedHtmlElement.HtmlElementAddress.HtmlTag.Attribute.Name, 
                TagAttributeValue = cachedHtmlElement.HtmlElementAddress.HtmlTag.Attribute.Value
            };


        }
    }
}