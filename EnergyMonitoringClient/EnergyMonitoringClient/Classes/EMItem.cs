using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyMonitoringClient.Classes
{
    internal class EMItem
    {
        public DataItem CPUTemperature { get; private set; }

        public EMItem()
        {
            CPUTemperature = new DataItem();
        }
    }
}
