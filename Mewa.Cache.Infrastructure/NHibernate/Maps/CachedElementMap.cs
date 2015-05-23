using FluentNHibernate.Mapping;
using Mewa.Cache.Domain;

namespace Mewa.Cache.Infrastructure.NHibernate.Maps
{
    //TODO maybe create CachedElementDao instead of domain object
    public class CachedElementMap : ClassMap<CachedElement>
    {
        public CachedElementMap()
        {
            Table("CachedElements");//TODO to constant
            Id(ce => ce.Id); //TODO add sequence
            Map(ce => ce.TagName);
            Map(ce => ce.TagValue);
            Map(ce => ce.Url);
            Map(ce => ce.Value);

        }
    }
}
