using System;
using System.Net;

namespace Mewa.Cache.WindowsServiceHost.HtmlProviders
{
    public static class HtmlStringProvider 
    {
        public static string GetHtmlString(string url)
        {
            //TODO error handling
            //TODO jeśli będzie więcej elementów to który zwrócić?
            //TODO trzeba włączyć webclienta w serwisach
            var html = String.Empty;
            using (var client = new WebClient())
            {
                client.Proxy = new WebProxy(new Uri("http://srvproxy.axa-pl.intraxa:80", true));
                html = client.DownloadString(url);
            }
            return html;
        }
    }
}