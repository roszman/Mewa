using System;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;

namespace Mewa.CacheService
{
    public partial class CacheService : ServiceBase
    {
        public CacheService(string[] args)
        {
            InitializeComponent();
            string eventSourceName = "MewaCacheSource";
            string logName = "MewaCacheLog";
            if (args.Any())
            {
                eventSourceName = args[0];
            }
            if (args.Count() > 1)
            {
                logName = args[1];
            } 
            eventLog1 = new EventLog();
            if (!EventLog.SourceExists(eventSourceName))
            {
                EventLog.CreateEventSource(eventSourceName, logName);
            }
            eventLog1.Source = eventSourceName;
            eventLog1.Log = logName;
        }

        protected override void OnStart(string[] args)
        {
            eventLog1.WriteEntry("MewaCacheService start.");
            // Set up a timer to trigger every minute.
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 30000; // 30 seconds
            timer.Elapsed += OnTimer;
            timer.Start();
            //zaladowac cache
        }

        protected override void OnStop()
        {
            eventLog1.WriteEntry("In onStop.");
        }

        public void OnTimer(object sender, System.Timers.ElapsedEventArgs args)
        {
            // TODO: Insert monitoring activities here.
            eventLog1.WriteEntry("Monitoring the System ", EventLogEntryType.Information, 1);
            //odswiezyc cache
        }
        protected override void OnContinue()
        {
            eventLog1.WriteEntry("In OnContinue.");
        }  
    }
    
}
