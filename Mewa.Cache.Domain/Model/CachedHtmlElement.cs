using System;

namespace Mewa.Cache.Domain.Model
{
    public class CachedHtmlElement
    {
        public CachedHtmlElement()
        {
            
        }
        public HtmlElementAddress HtmlElementAddress { get; set; }
        public string InnerHtml { get; set; }
        public DateTime LastRefreshDate { get; set; }
        //TODO remove constructor
        public CachedHtmlElement(HtmlElementAddress htmlElementAddress, string innerHtml)
        {
            HtmlElementAddress = htmlElementAddress;
            InnerHtml = innerHtml;
        }
    }
}
