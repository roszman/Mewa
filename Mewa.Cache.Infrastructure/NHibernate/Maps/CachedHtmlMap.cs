using FluentNHibernate.Mapping;
using Mewa.Cache.Infrastructure.NHibernate.Daos;

namespace Mewa.Cache.Infrastructure.NHibernate.Maps
{
    //TODO maybe create CachedHtmlElementDao instead of domain object
    public class CachedHtmlMap : ClassMap<CachedHtmlElementDao>
    {
        public CachedHtmlMap()
        {
            Table("CachedHtmlElements");//TODO to constant
            Id(ce => ce.Id); //TODO add sequence and generator
            Component(ce => ce.CachedHtmlElement, che =>
            {
                che.Component(m => m.HtmlElementAddress, hea =>
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
                che.Map(m => m.InnerHtml).Column("HtmlElementInnerHtml");
                che.Map(m => m.LastRefreshDate).Column("LastRefreshDate");
            });
            //Map(ce => ce.CachedHtmlElement.HtmlElementAddress.Url)
                //.Column("Url");
            //Map(ce => ce.CachedHtmlElement.HtmlElementAddress.HtmlTag.Name)
                //.Column("HtmlElementName");
            //Map(ce => ce.CachedHtmlElement.HtmlElementAddress.HtmlTag.Attribute.Name)
            //    .Column("HtmlElementAttributeName");
            //Map(ce => ce.CachedHtmlElement.HtmlElementAddress.HtmlTag.Attribute.Value)
            //    .Column("HtmlElementAttributeValue");
            //Map(ce => ce.CachedHtmlElement.InnerHtml.Value)
            //    .Column("HtmlElementInnerHtml");
            //Map(ce => ce.CachedHtmlElement.LastRefreshDate)
                //.Column("LastRefreshDate");
        }
    }
}
