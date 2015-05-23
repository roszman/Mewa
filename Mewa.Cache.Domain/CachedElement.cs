namespace Mewa.Cache.Domain
{
    public class CachedElement
    {
        public virtual long Id { get; set; }
        public virtual string Url { get; set; }
        public virtual string TagName { get; set; }
        public virtual string TagValue { get; set; }
        public virtual string Value { get; set; }
    }
}