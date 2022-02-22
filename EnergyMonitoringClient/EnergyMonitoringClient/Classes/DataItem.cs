using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EnergyMonitoringClient.Classes
{
    public class DataItem
    {
        public double AverageValue { get { return values.Average(); } }
        public double MaxValue { get { return values.Max(); } }
        public double MinValue { get { return values.Min(); } }
        public int ValueCount { get { return values.Count; } }
        private List<double> values;

        internal DataItem()
        {
            Reset();
        }

        public void Reset()
        {
            values = new List<double>();
        }

        public void AddValue(double value)
        {
            values.Add(value);
        }
    }
}
