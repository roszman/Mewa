using Mewa.CacheService;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mewa.Cache.UnitTests.CacheService
{
    [TestClass]
    public class HtmlTagBodyProviderTest
    {
        [TestMethod]
        public void GetTagValue_ValidTripleConfig_ReturnHtmlTagValue()
        {
            //TODO take html from the local resource
            var webCrawler = new HtmlStringProvider();
            //<div id="bakgrunnsbilde">
            var htmlString = webCrawler.GetHtmlString(
                    "http://splash.seagull.no/splash/");
            
            var tagBodyProvider = new HtmlTagBodyProvider();
            var htmlTag = tagBodyProvider.GetTagBodyFromHtml(htmlString, "div", "id", "bakgrunnsbilde");
            
            Assert.AreEqual(@"<img src=""img/Bakgrunnsbilde_520.png"" width=""520"" height=""340"" alt=""Bakgrunnsbilde"">", htmlTag);
        }
    }
} 