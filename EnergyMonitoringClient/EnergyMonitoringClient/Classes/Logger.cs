using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;

namespace EnergyMonitoringClient.Classes
{
    internal class Logger
    {
        private static Logger current;
        public static Logger Current
        {
            get
            {
                if (current == null)
                {
                    current = new Logger();
                }
                return current;
            }
        }

        private TelemetryClient? telemetryClient = null;
        private int flushCounter = 0;
        private int flushMaxCounter = 5;

        public Logger()
        {
            string? instrumentationKey = Helper.GetAppSetting(AppSettings.AppInsights_InstrumentationKey);
            if (instrumentationKey != null)
            {
                TelemetryConfiguration configuration = TelemetryConfiguration.CreateDefault();
                // thisisnotatest
                configuration.InstrumentationKey = instrumentationKey;
                telemetryClient = new TelemetryClient(configuration);
            }
        }

        public void TrackEvent(string eventName)
        {
            if (telemetryClient == null) return;
            telemetryClient.TrackEvent(eventName);
        }

        public void TrackMetric(string name, double value)
        {
            if (telemetryClient == null) return;
            telemetryClient.TrackMetric(name, value);
        }

        public void TrackAvailability(string name)
        {
            if (telemetryClient == null) return;
            telemetryClient.TrackAvailability(name, DateTime.Now, TimeSpan.FromSeconds(1), name, true);
        }

        public void Flush()
        {
            telemetryClient.Flush();
        }
    }
}
