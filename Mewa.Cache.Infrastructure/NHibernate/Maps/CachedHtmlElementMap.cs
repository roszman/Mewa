using FluentNHibernate.Mapping;
using Mewa.Cache.Domain.Model;
using Mewa.Cache.Infrastructure.NHibernate.Daos;

namespace Mewa.Cache.Infrastructure.NHibernate.Maps
{
    //TODO maybe create CachedHtmlElementDao instead of domain object
    public class CachedHtmlElementMap : ClassMap<CachedHtmlElement>
    {
        public CachedHtmlElementMap()
        {
            Table("CachedHtmlElements");//TODO to constant
            Id(ce => ce.Id); //TODO add sequence and generator
            Component(m => m.HtmlElementAddress, hea =>
            {
                hea.Map(m => m.Url).Column("Url");
                hea.Component(m => m.HtmlTag, ht =>
                {
                    ht.Map(m => m.Name).Column("HtmlElementName");
                    ht.Component(m => m.Attribute, hta =>
                    {
                        hta.Map(m => m.Name).Column("HtmlElementAttributeName");
                        hta.Map(m => m.Value).Column("HtmlElementAttributeValue");
                    });
                });
            });
            Map(m => m.InnerHtml).Column("HtmlElementInnerHtml");
            Map(m => m.LastRefreshDate).Column("LastRefreshDate");
         
        }
    }
}
