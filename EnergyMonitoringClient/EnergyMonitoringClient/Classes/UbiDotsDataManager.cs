using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EnergyMonitoringClient.Classes
{
    internal class UbiDotsDataManager
    {
        private static UbiDotsDataManager current;
        public static UbiDotsDataManager Current
        {
            get
            {
                if (current == null)
                {
                    current = new UbiDotsDataManager();
                }
                return current;
            }
        }

        private string? token = null;
        private string? dataUrl = null;
        private WebClient client = null;

        private UbiDotsDataManager()
        {
            token = Helper.GetAppSetting(AppSettings.UbiDots_Token);
            dataUrl = Helper.GetAppSetting(AppSettings.UbiDots_DataUrl);
            if ( !dataUrl.EndsWith("/")) dataUrl = dataUrl + "/";
            client = new WebClient();
            client.Headers.Add("X-Auth-Token", token);
            client.Headers.Add("Content-Type", "application/json");
;        }

        public void LogData(string deviceName, object data)
        {
            if (token == null || dataUrl == null) return;

            Logger.Current.LogConsole("Ubidots - LogData");
            string fullUrl = dataUrl + deviceName;
            string dataJSON = JsonConvert.SerializeObject(data);

            client.UploadData(fullUrl,  Encoding.UTF8.GetBytes(dataJSON));
        }
    }
}
