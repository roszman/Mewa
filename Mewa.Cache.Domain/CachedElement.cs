namespace Mewa.Cache.Domain
{
    public class CachedElement
    {
        public virtual long Id { get; set; }
        public virtual string Url { get; set; }
        public virtual string TagName { get; set; }
        public virtual string TagAttributeName { get; set; }
        public virtual string TagAttributeValue { get; set; }
        public virtual string TagValue { get; set; }
    }
}