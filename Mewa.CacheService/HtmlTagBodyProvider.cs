using HtmlAgilityPack;

namespace Mewa.CacheService
{
    public class HtmlTagBodyProvider
    {
        public string GetTagBodyFromHtml(string htmlString, string tagName, string tagAttributeName, string tagAttributeValue)
        {
            var htmlDoc = new HtmlDocument();
            //TODO what if the arguments are null?
            htmlDoc.LoadHtml(htmlString);
            var htmlTag = htmlDoc.DocumentNode.SelectSingleNode(
                string.Format("//{0}[@{1}='{2}']", tagName, tagAttributeName, tagAttributeValue));
            if (htmlTag != null)
            {
                return htmlTag.InnerHtml.Trim();
            }
            //TODO error handling, error logging
            return string.Empty;
        }
    }
}
