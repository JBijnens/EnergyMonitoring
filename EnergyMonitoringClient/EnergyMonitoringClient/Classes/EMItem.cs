using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyMonitoringClient.Classes
{
    public class EMItem
    {
        public DataItem CPUTemperature { get; private set; }
        public DataItem PowerConsumption { get; private set; }
        public DataItem PowerGeneration { get; private set; }

        public EMItem()
        {
            CPUTemperature = new DataItem();
            PowerConsumption = new DataItem();
            PowerGeneration = new DataItem();
        }
    }
}
