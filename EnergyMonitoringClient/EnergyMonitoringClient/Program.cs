using EnergyMonitoringClient.Classes;
using Iot.Device.CpuTemperature;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;

string machineName = Environment.MachineName;
Logger.Current.TrackEvent("Start client on '" + machineName + "'");
Logger.Current.TrackAvailability(machineName);

var dataConsumers = new List<DataConsumerBase>();
dataConsumers.Add(new ConsoleDataConsumer());

// Log start
dataConsumers.ForEach(a => a.LogEvent(Helper.MachineName + ": Start"));

// Main data object
var mainData = new EMItem();

// Timer configuration
TimingManager.Current.Callback = timerCallBack01;

void timerCallBack01(object? obj)
{
    Console.WriteLine("----");

    var temps = Helper.GetTemperatures();
    mainData.CPUTemperature.AddValue(temps.First().Value);

    dataConsumers.ForEach(a => a.LogEvent("Loop", mainData));

}

while (true)
{
    // Do nothing
}
Console.WriteLine("Done");