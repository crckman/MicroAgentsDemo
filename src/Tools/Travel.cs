namespace Microagents.Tools;

using Microsoft.SemanticKernel;
using System;
using System.ComponentModel;
using System.Text.Json;

public class Travel : DiagnosticPlugin
{
    private readonly Dictionary<string, IList<FlightListing>> events = [];

    [KernelFunction]
    [Description("Search for available flights and provide list of flight numbers for a given date.")]
    public string ListFlights(
        [Description("The airport code of the departing flight.")]
        string from,
        [Description("The airport code of the arriving flight.")]
        string to,
        [Description("The date of the flight.")]
        string when)
    {
        var listings = GetFlightListings(from, to, when);

        return
            CaptureCall(
                nameof(ListFlights),
                JsonSerializer.Serialize(listings),
                new()
                {
                    { nameof(when), when },
                    { nameof(from), from },
                    { nameof(to), to },
                });
    }

    [KernelFunction]
    [Description("Book the given flight by flight number.")]
    public void BookFlight(string flightNumber)
    {
        CaptureCall(
            nameof(BookFlight),
            string.Empty,
            new()
            {
                { nameof(flightNumber), flightNumber },
            });
    }

    private IList<FlightListing> GetFlightListings(string from, string to, string when)
    {
        var key = $"{from}-{to}-{when}";

        if (!events.TryGetValue(key, out var listings))
        {
            listings = GenerateFlightListings(from, to, when).ToArray();
            events[key] = listings;
        }

        return listings;
    }

    private IEnumerable<FlightListing> GenerateFlightListings(string from, string to, string when)
    {
        yield return new FlightListing(Guid.NewGuid().ToString(), MakeFlightNumber(), from, "PDX", when, "$99.99");
        yield return new FlightListing(Guid.NewGuid().ToString(), MakeFlightNumber(), from, "YVR", when, "72.00");
        yield return new FlightListing(Guid.NewGuid().ToString(), MakeFlightNumber(), from, to, when, "$129.99");
        yield return new FlightListing(Guid.NewGuid().ToString(), MakeFlightNumber(), from, to, when, "$92.75");

        static string MakeFlightNumber() => $"{(char)('A' + Random.Shared.Next(26))}{(char)('A' + Random.Shared.Next(26))}{Random.Shared.Next(10)}{Random.Shared.Next(10)}{Random.Shared.Next(10)}";
    }

    private record FlightListing(
        string Id,
        string FlightNumber,
        string From,
        string To,
        string When,
        string Price,
        string Description = "one-way");
}
