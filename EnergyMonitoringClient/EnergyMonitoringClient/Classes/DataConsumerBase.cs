using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyMonitoringClient.Classes
{
    internal abstract class DataConsumerBase
    {
        internal DataConsumerBase()
        {

        }

        internal abstract void LogEvent(string eventName, object? data);


    }
}
