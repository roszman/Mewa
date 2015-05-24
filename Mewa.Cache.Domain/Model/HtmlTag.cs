namespace Mewa.Cache.Domain.Model
{
    public class HtmlTag
    {
        public HtmlTag()
        {
            
        }
        public string Name { get; set; }
        public HtmlTagAttribute Attribute { get; set; }

        //TODO remove constructor
        public HtmlTag(string name, HtmlTagAttribute attribute)
        {
            Name = name;
            Attribute = attribute;
        }
    }
}
