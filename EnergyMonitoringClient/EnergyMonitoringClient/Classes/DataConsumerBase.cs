using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyMonitoringClient.Classes
{
    internal abstract class DataConsumerBase
    {
        /// <summary>
        /// The period for aggregating data befor logging (in seconds)
        /// </summary>
        internal int LogPeriod { get; set; }

        /// <summary>
        /// The latest period which was logged
        /// </summary>
        protected int LastLoggedPeriod = -1;

        /// <summary>
        /// The current period at the moment
        /// </summary>
        protected int CurrentPeriod
        {
            get
            {
                int secondsToday = DateTime.Now.Second + DateTime.Now.Minute * 60 + DateTime.Now.Hour * 3600;
                return (int)Math.Floor(1.0 * secondsToday / LogPeriod);
            }
        }

        internal DataConsumerBase()
        {
            // Default 5 minutes
            LogPeriod = 5 * 60;
        }

        internal abstract void LogEvent(string eventName, object? data = null);
        internal abstract void LogData(EMItem mainData);

        protected bool ShouldRun()
        {
            return LastLoggedPeriod != CurrentPeriod;
        }
    }
}
