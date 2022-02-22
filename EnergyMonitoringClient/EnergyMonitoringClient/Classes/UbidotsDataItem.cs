using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EnergyMonitoringClient.Classes
{
    public class UbidotsDataItem
    {
        [JsonProperty("CPU Temp")]
        public UbidotsDataProperty CPUTemperature { get; set; }
        public UbidotsDataProperty PowerConsumption { get; set; }
        public UbidotsDataProperty PowerGeneration { get; set; }

        public UbidotsDataItem(long timestamp, EMItem mainData)
        {            
            CPUTemperature = new UbidotsDataProperty(timestamp, mainData.CPUTemperature.AverageValue);
            PowerConsumption = new UbidotsDataProperty(timestamp, mainData.PowerConsumption.AverageValue);
            PowerGeneration = new UbidotsDataProperty(timestamp, mainData.PowerGeneration.AverageValue);
        }
    }

    public class UbidotsDataProperty
    {
        public double value { get; set; }
        public long timestamp { get; set; }

        public UbidotsDataProperty(long timestamp, double value)
        {
            this.value = value;
            this.timestamp = timestamp;            
        }
    }
}
