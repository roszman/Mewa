using System;
using System.Collections.Generic;
using System.Configuration;
using System.ServiceProcess;
using Castle.Core.Logging;
using Mewa.Cache.Domain.Model;
using Mewa.Cache.Domain.Repository;
using Mewa.Cache.WindowsServiceHost.HtmlProviders;

namespace Mewa.Cache.WindowsServiceHost
{
    public partial class HtmlCacheService : ServiceBase
    {
        private IEnumerable<CachedHtmlElement> _cachedHtmlElements;
        private ICachedHtmlElementsRepository _cachedHtmlElementsRepository;
        public ILogger Logger { get; set; }
        public HtmlCacheService(ICachedHtmlElementsRepository cachedHtmlElementsRepository)
        {
            _cachedHtmlElementsRepository = cachedHtmlElementsRepository;
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Logger.Info("Html cache service start.");

            _cachedHtmlElements = _cachedHtmlElementsRepository.GetAllHtmlElements();
            RefreshHtmlElementsCache();

            StartTimer();
        }

        protected override void OnStop()
        {
            Logger.Info("Html cache service stop.");
        }

        public void OnTimer(object sender, System.Timers.ElapsedEventArgs args)
        {
            RefreshHtmlElementsCache();
        }

        private void RefreshHtmlElementsCache()
        {
            Logger.Info("Html cache refresh start.");
            //TODO zalozenie ze cache laduje sie tylko podczas startu uslugi, co oznacza ze dodanie nowych elementow do skeszowania wymaga restartu
            foreach (var cachedHtmlElement in _cachedHtmlElements)
            {
                //Error/null handling and logging
                var htmlString = HtmlStringProvider.GetHtmlString(cachedHtmlElement.HtmlElementAddress.Url);
                var newHtmlString = HtmlTagBodyProvider.GetTagBodyFromHtml(
                    htmlString,
                    cachedHtmlElement.HtmlElementAddress.HtmlTag.Name,
                    cachedHtmlElement.HtmlElementAddress.HtmlTag.Attribute.Name,
                    cachedHtmlElement.HtmlElementAddress.HtmlTag.Attribute.Value
                    );

                if (htmlString != newHtmlString)
                {
                    cachedHtmlElement.InnerHtml = newHtmlString;
                    _cachedHtmlElementsRepository.Update(cachedHtmlElement);
                }
            }
            Logger.Info("Html cache refreshed.");
        }

        private void StartTimer()
        {
            Logger.Info("Html cache service timer started.");
            //TODO errors/null handling
            int hours = Int32.Parse(ConfigurationManager.AppSettings["HourlyInterval"]);
            var timer = new System.Timers.Timer
            {
                Interval = GetSecondsFromHours(hours)
            };
            timer.Elapsed += OnTimer;
            timer.Start();
        }

        private static int GetSecondsFromHours(int hours)
        {
            return hours * 3600;
        }
    }
}
