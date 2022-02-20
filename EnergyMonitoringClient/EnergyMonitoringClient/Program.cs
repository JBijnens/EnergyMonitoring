using EnergyMonitoringClient.Classes;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;

Logger.Current.TrackEvent("test 4645646");




for (int i = 0; i < 100; i++)
{
    Console.WriteLine("Tracking event " + i);
    Logger.Current.TrackMetric("Temperature", i);
        
}


Console.WriteLine("Done");