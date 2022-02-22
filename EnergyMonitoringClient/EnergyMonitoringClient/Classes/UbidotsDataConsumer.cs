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

        internal override void LogEvent(string eventName, object? data)
        {
            if (token == null || dataUrl == null) return;

            Logger.Current.LogConsole("Ubidots - LogData");
            string fullUrl = dataUrl + Helper.MachineName;
            string dataJSON = JsonConvert.SerializeObject(data);

            client.UploadData(fullUrl, Encoding.UTF8.GetBytes(dataJSON));
        }

       
    }
}
