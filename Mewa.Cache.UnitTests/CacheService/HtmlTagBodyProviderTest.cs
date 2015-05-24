using Mewa.Cache.WindowsServiceHost;
using Mewa.Cache.WindowsServiceHost.HtmlProviders;
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
            //<div id="bakgrunnsbilde">
            var htmlString = HtmlStringProvider.GetHtmlString(
                    "http://splash.seagull.no/splash/");
            
            var htmlTag = HtmlTagBodyProvider.GetTagBodyFromHtml(htmlString, "div", "id", "bakgrunnsbilde");
            
            Assert.AreEqual(@"<img src=""img/Bakgrunnsbilde_520.png"" width=""520"" height=""340"" alt=""Bakgrunnsbilde"">", htmlTag);
        }
    }
} 