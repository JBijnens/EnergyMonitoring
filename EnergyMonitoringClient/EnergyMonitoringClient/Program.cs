using EnergyMonitoringClient.Classes;
using Iot.Device.CpuTemperature;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;

string machineName = Environment.MachineName;
Logger.Current.TrackEvent("Start client on '" + machineName + "'");
Logger.Current.TrackAvailability(machineName);

// CPU Temperature
CpuTemperature cpuTemperature = new CpuTemperature();
string temperatureMetric = machineName + ".CPUTemperature.";

// Timer configuration
TimingManager.Current.Callback = timerCallBack01;

void timerCallBack01(object? obj)
{
    Console.WriteLine("----");
    Logger.Current.TrackAvailability(machineName);

    // Log temperature
    if(cpuTemperature.IsAvailable)
    {
        var temperatures = cpuTemperature.ReadTemperatures();
        foreach (var temperature in temperatures)
        {
            Logger.Current.TrackMetric(temperatureMetric + temperature.Sensor, temperature.Temperature.DegreesCelsius);
        }
        
    }
    
    // Flush log
    Logger.Current.Flush();
}

while (true)
{
    // Do nothing
}
Console.WriteLine("Done");