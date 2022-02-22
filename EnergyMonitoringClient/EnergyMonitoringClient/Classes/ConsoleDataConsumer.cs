using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EnergyMonitoringClient.Classes
{
    internal class ConsoleDataConsumer : DataConsumerBase
    {
        internal ConsoleDataConsumer()
        {

        }

        internal override void LogEvent(string eventName, object? data)
        {
            if (data == null)
            {
                Console.WriteLine(DateTime.Now.ToString("O") + " - Event '" + eventName + "'");
            }
            else
            {
                Console.WriteLine(DateTime.Now.ToString("O") + " - Event '" + eventName + "': " + JsonConvert.SerializeObject(data));
            }
        }

        internal override void LogData(EMItem data)
        {
            if (data == null)
            {
                Console.WriteLine(DateTime.Now.ToString("O") + " - LogData : " + JsonConvert.SerializeObject(data));
            }
        }
    }
}
