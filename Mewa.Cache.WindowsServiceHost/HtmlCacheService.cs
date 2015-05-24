using System.Collections.Generic;
using System.ServiceProcess;
using Castle.Core.Logging;
using Castle.Facilities.Logging;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Mewa.Cache.Domain.Model;
using Mewa.Cache.Domain.Repository;
using Mewa.Cache.Infrastructure.Installer;

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

            var cachedHtmlRepository = _container.Resolve<ICachedHtmlElementsRepository>();
            var cachedHtmlElements = cachedHtmlRepository.GetCachedElements();

            // Set up a timer to trigger every minute.
            StartTimer();
        }

        private void StartTimer()
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 60000; // 60 seconds
            timer.Elapsed += OnTimer;
            timer.Start();
        }

        protected override void OnStop()
        {
            Logger.Info("Html cache service stop.");
        }

        public void OnTimer(object sender, System.Timers.ElapsedEventArgs args)
        {
            // TODO: Insert monitoring activities here.
            
            Logger.Info("Html cache service timer event.");
        }
    }
}
