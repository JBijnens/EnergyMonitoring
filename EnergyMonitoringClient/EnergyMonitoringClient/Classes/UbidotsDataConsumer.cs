using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EnergyMonitoringClient.Classes
{
    internal class UbidotsDataConsumer : DataConsumerBase
    {
        private string? token = null;
        private string? dataUrl = null;
        private WebClient client = null;

        internal UbidotsDataConsumer()
        {            
            Logger.Current.LogConsole("UbidotsDataConsumer created");
            token = Helper.GetAppSetting(AppSettings.UbiDots_Token);
            dataUrl = Helper.GetAppSetting(AppSettings.UbiDots_DataUrl);
            if (!dataUrl.EndsWith("/")) dataUrl = dataUrl + "/";
            client = new WebClient();
            client.Headers.Add("X-Auth-Token", token);
            client.Headers.Add("Content-Type", "application/json");
        }

        internal UbidotsDataConsumer(int logInterval) : this()
        {
            LogPeriod = logInterval;
        }

        internal override void LogEvent(string eventName, object? data)
        {
            // Not implemented
        }

        internal override void LogData(EMItem mainData)
        {
            if (!ShouldRun()) return;

            Console.WriteLine("LogData Ubidots");
            string fullUrl = dataUrl + Helper.MachineName;
                        
            var ubidotsData = new UbidotsDataItem(Helper.GetEpochTime(DateTime.Now), mainData);
            var serializedData = JsonConvert.SerializeObject(ubidotsData);
            Console.WriteLine("Data: " + serializedData);
            client.UploadData(fullUrl, Encoding.UTF8.GetBytes(serializedData));

            LastLoggedPeriod = CurrentPeriod;
        }       
    }

    
}
