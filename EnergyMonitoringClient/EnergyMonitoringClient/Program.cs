using EnergyMonitoringClient.Classes;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;

Logger.Current.TrackEvent("test 4645646");

/*
client.TrackEvent("Running on OrangePi");

for (int i = 0; i < 100; i++)
{
    Console.WriteLine("Tracking event " + i);
    client.TrackEvent("Event " + i);

    Console.WriteLine("Tracking Availability " + i);
    client.TrackAvailability("Service1", DateTime.Now, TimeSpan.FromMinutes(1), "home", true, "testing " + i);

    client.Flush();
}
*/

Console.WriteLine("Done");