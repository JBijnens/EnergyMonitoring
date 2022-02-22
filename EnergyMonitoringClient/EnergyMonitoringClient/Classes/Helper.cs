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
        internal static string MachineName
        {
            get { return Environment.MachineName; }
        }

        private static CpuTemperature cpuTemperature = new CpuTemperature();
        internal static Dictionary<string, double> GetTemperatures()
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

        internal static string? GetAppSetting(AppSettings setting)
        {
            return ConfigurationManager.AppSettings[setting.ToString()];
        }

        internal static long GetEpochTime(DateTime dateTime)
        {
            // https://www.epochconverter.com/
            return ((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds() * 1000;
        }


    }
}
