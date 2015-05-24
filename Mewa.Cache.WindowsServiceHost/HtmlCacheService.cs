using System.Collections.Generic;
using System.ServiceProcess;
using Castle.Core.Logging;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Mewa.Cache.Domain.Model;
using Mewa.Cache.Domain.Repository;
using Mewa.Cache.Infrastructure.Installer;
using Mewa.Cache.WindowsServiceHost.HtmlProviders;

namespace Mewa.Cache.WindowsServiceHost
{
    public partial class HtmlCacheService : ServiceBase
    {
        private IWindsorContainer _container;
        private IEnumerable<CachedHtmlElement> cachedHtmlElements;
        private ICachedHtmlElementsRepository cachedHtmlElementsRepository;
        public ILogger Logger { get; set; }
        public HtmlCacheService()
        {
            InitializeComponent();
            //TODO create installer
            _container = new WindsorContainer();
            _container.Install(Configuration.FromAppConfig());
            _container.Install(new InfrastructureInstaller());
            Logger = NullLogger.Instance;
        }

        protected override void OnStart(string[] args)
        {
            Logger.Info("Html cache service start.");

            cachedHtmlElementsRepository = _container.Resolve<ICachedHtmlElementsRepository>();
            cachedHtmlElements = cachedHtmlElementsRepository.GetAllHtmlElements();
            CheckHtmlElements();
            // Set up a timer to trigger every minute.
            StartTimer();
        }

        protected override void OnStop()
        {
            Logger.Info("Html cache service stop.");
        }

        public void OnTimer(object sender, System.Timers.ElapsedEventArgs args)
        {
            // TODO: Insert monitoring activities here.
            CheckHtmlElements();
            Logger.Info("Html cache service timer event.");
        }

        private void CheckHtmlElements()
        {
            //TODO zalozenie ze cache laduje sie tylko podczas startu uslugi, co oznacza ze dodanie nowych elementow do skeszowania wymaga restartu
            foreach (var cachedHtmlElement in cachedHtmlElements)
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
                    cachedHtmlElementsRepository.Update(cachedHtmlElement);
                }
                cachedHtmlElementsRepository.Update(cachedHtmlElement);
            }
        }

        private void StartTimer()
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 20000; // 60 seconds
            timer.Elapsed += OnTimer;
            timer.Start();
        }
    }
}
