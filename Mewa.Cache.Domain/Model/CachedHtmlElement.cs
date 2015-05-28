using System;

namespace Mewa.Cache.Domain.Model
{
    public class CachedHtmlElement
    {
        public CachedHtmlElement()
        {
            
        }
        //TODO i choose to use domain model as repository model, i think it is ok for this simple solution. 
        public virtual long Id { get; set; }
        public virtual HtmlElementAddress HtmlElementAddress { get; set; }
        public virtual string InnerHtml { get; set; }
        public virtual DateTime? LastRefreshDate { get; set; }
        //TODO remove constructor
        public CachedHtmlElement(HtmlElementAddress htmlElementAddress, string innerHtml)
        {
            HtmlElementAddress = htmlElementAddress;
            InnerHtml = innerHtml;
        }
    }
}
