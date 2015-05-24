namespace Mewa.Cache.Domain.Model
{
    public class HtmlTagAttribute
    {
        public HtmlTagAttribute()
        {
            
        }
        public string Name { get; set; }
        public string Value { get; set; }

        //TODO remove constructor
        public HtmlTagAttribute(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}