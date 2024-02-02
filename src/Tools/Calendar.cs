namespace Microsoft.Microagents.Tools;

using Microsoft.SemanticKernel;
using System.ComponentModel;
using System.Text.Json;

public class Calendar : DiagnosticPlugin
{
    private static readonly DateTime Now = DateTime.Now;
    private static readonly DateTime NextMonth = new(Now.Year, DateTime.Now.AddMonths(1).Month, 1);
    private static readonly int TargetMonth = NextMonth.Month;
    private static readonly int TargetYear = NextMonth.Year;

    private readonly List<CalendarEvent> events = [];

    private List<CalendarEvent> Events
    {
        get
        {
            if (events.Count == 0)
            {
                events.Add(new CalendarEvent($"{TargetMonth}-1-{TargetYear}", "Dinner with Fred", "Just hanging out"));
                events.Add(new CalendarEvent($"{TargetMonth}-11-{TargetYear} to {TargetMonth}-13-{TargetYear}", "Work trip", "Important client"));
                events.Add(new CalendarEvent($"{TargetMonth}-17-{TargetYear}", "Doctor"));
                events.Add(new CalendarEvent($"{TargetMonth}-19-{TargetYear}", "Dentist"));
            }

            return events;
        }
    }

    [KernelFunction]
    public string GetCurrentDate()
    {
        return
            CaptureCall(
                nameof(GetCurrentDate),
                DateTime.Now.Date.ToLongDateString());
    }

    [KernelFunction]
    [Description("Get list of scheduled events within the specified date range.")]
    public string GetEvents(
        [Description("The first date in the range")]
        string from,
        [Description("The last date in the range")]
        string to)
    {
        var fromDate = DateTime.Parse(from);
        var toDate = DateTime.Parse(to);
        var result = (fromDate > NextMonth.AddMonths(1) || toDate < NextMonth) ? [] : Events;

        return
            CaptureCall(
                nameof(GetEvents),
                JsonSerializer.Serialize(result),
                new()
                {
                    { nameof(from), from },
                    { nameof(to), to },
                });
    }

    [KernelFunction]
    [Description("Create a new scheduled event.")]
    public void NewEvent(string when, string title, string? description = null)
    {
        Events.Add(new CalendarEvent(when, title, description));

        CaptureCall(
            nameof(NewEvent),
            string.Empty,
            new()
            {
                { nameof(when), when },
                { nameof(title), title },
                { nameof(description), description },
            });
    }

    private record CalendarEvent(
        string Date,
        string Title,
        string? Description = null);
}
