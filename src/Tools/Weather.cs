namespace Microsoft.Microagents.Tools;

using Microsoft.SemanticKernel;
using System;
using System.ComponentModel;
using System.Text.Json;

public class Weather : DiagnosticPlugin
{
    private readonly Dictionary<string, WeatherForecast> forecasts = [];

    [KernelFunction]
    [Description("Get the weather forecast for the given date and location.  Dates farther than 15 days out will use historical data.")]
    public string GetForecast(
        string date,
        string location)
    {
        var listings = LookupForecast(date, location);

        return
            CaptureCall(
                nameof(GetForecast),
                JsonSerializer.Serialize(listings),
                new()
                {
                    { nameof(date), date },
                    { nameof(location), location },
                });
    }

    private WeatherForecast LookupForecast(string date, string location)
    {
        var key = $"{date}-{location}";

        if (!forecasts.TryGetValue(key, out var forecast))
        {
            forecast = GenerateForecast(date, location);
            forecasts[key] = forecast;
        }

        return forecast;
    }

    private WeatherForecast GenerateForecast(string date, string location)
    {
        var highTemp = Random.Shared.Next(49, 96);
        var lowTemp = highTemp - Random.Shared.Next(12, 20);
        var precip = Random.Shared.Next(0, 80);

        return
            new WeatherForecast(
                date,
                location,
                $"{highTemp} F",
                $"{lowTemp} F",
                $"{precip} %");
    }

    private record WeatherForecast(
        string Date,
        string Location,
        string HighTemperature,
        string LowTemperature,
        string Precipition);
}
