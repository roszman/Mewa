namespace Mewa.Cache.Domain
{
    public class CachedElement
    {
        public long Id { get; set; }
        public string Url { get; set; }
        public string TagName { get; set; }
        public string TagValue { get; set; }
        public string Value { get; set; }
    }
}