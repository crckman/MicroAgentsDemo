namespace Microagents.Tools;

using Microsoft.SemanticKernel;
using System.ComponentModel;

public class Location : DiagnosticPlugin
{
    [KernelFunction]
    [Description("Provide the user's location by city, region, and country.")]
    public string GetCurrentLocation()
    {
        return
            CaptureCall(
                nameof(GetCurrentLocation),
                "Redmond, WA, USA");
    }

    [KernelFunction]
    [Description("Provide the user's home location by city, region, and country.")]
    public string GetHomeLocation()
    {
        return
            CaptureCall(
                nameof(GetCurrentLocation),
                "Seattle, WA, USA");
    }

    [KernelFunction]
    [Description("Provide the city, region, and country of the given latitude and longitude.")]
    public string GetLocation(string latitude, string longitude)
    {
        return
            CaptureCall(
                nameof(GetLocation),
                "XYZ, TX, USA",
                new()
                {
                    { nameof(latitude), latitude },
                    { nameof(longitude), longitude },
                });

    }
}
