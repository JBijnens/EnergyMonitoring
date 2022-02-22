using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iot.Device.CpuTemperature;

namespace EnergyMonitoringClient.Classes
{
    internal enum AppSettings
    {
        AppInsights_InstrumentationKey,
        UbiDots_Token,
        UbiDots_DataUrl
    }

    internal class Helper
    {
        public static string MachineName
        {
            get { return Environment.MachineName; }
        }

        private static CpuTemperature cpuTemperature = new CpuTemperature();
        public static Dictionary<string, double> GetTemperatures()
        {
            Dictionary<string, double> temperatures = new Dictionary<string, double>();
            if (cpuTemperature.IsAvailable)
            {
                var cputemps = cpuTemperature.ReadTemperatures();
                foreach (var cputemp in cputemps)
                {
                    temperatures.Add(cputemp.Sensor, cputemp.Temperature.DegreesCelsius);
                }               
            }
            else
            {
                temperatures.Add("CPU", DateTime.Now.Second);
            }
            return temperatures;
        }

        public static string? GetAppSetting(AppSettings setting)
        {
            return ConfigurationManager.AppSettings[setting.ToString()];
        }


    }
}
