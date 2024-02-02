namespace Microagents.Tools;

using Microsoft.SemanticKernel;
using System.ComponentModel;

public class Airline : DiagnosticPlugin
{
    [KernelFunction]
    public string GetFlightStatus(
        [Description("The airport code of the flight.")]
        string airport,
        string flightNumber)
    {
        return
            CaptureCall(
                nameof(GetFlightStatus),
                $"Expected arrival to {airport} at 13:13 PST",
                new()
                {
                    { nameof(flightNumber), flightNumber },
                });
    }
}
