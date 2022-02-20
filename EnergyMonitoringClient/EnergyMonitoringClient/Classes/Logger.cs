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
            telemetryClient.Flush();            
        }

        public void TrackMetric(string name, double value)
        {
            if (telemetryClient == null) return;
            telemetryClient.TrackMetric(name, value);
            telemetryClient.Flush();
        }
    }
}
