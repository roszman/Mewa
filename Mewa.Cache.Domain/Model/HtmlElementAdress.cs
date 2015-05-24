namespace Mewa.Cache.Domain.Model
{
    public class HtmlElementAddress
    {
        public HtmlElementAddress()
        {
            
        }
        public string Url { get; set; }
        public HtmlTag HtmlTag { get; set; }

        //TODO remove constructor
        public HtmlElementAddress(string url, HtmlTag htmlTag)
        {
            Url = url;
            HtmlTag = htmlTag;
        }
    }
}
