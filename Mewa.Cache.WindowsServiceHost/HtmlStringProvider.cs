using System;
using System.Net;

namespace Mewa.Cache.WindowsServiceHost
{
    public static class HtmlStringProvider 
    {
        public static string GetHtmlString(string url)
        {
            //TODO error handling
            //TODO jeśli będzie więcej elementów to który zwrócić?
            var html = String.Empty;
            using (var client = new WebClient())
            {
                html = client.DownloadString(url);
            }
            return html;
        }
    }
}