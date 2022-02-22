using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static string? GetAppSetting(AppSettings setting)
        {
            return ConfigurationManager.AppSettings[setting.ToString()];
        }


    }
}
