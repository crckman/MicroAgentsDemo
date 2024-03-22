namespace Microagents;

using Microagents.Demos;
using Microagents.Strategies;

internal class Program
{
    private enum Demo
    {
        Calendar,
        Banking,
        Travel,
    }

    private static readonly Dictionary<Demo, Func<StrategyDemo>> demos =
        new()
        {
            { Demo.Calendar, () => new CalendarDemo() },
            { Demo.Banking, () => new BankingDemo() },
            { Demo.Travel, () => new TravelDemo() },
        };

    /// <summary>
    /// Entry point for demo.
    /// For configuration: See <see cref="Config"/>.
    /// </summary>
    static async Task Main(string[] args)
    {
        Demo flavor = Demo.Calendar;

        if (args.Length > 1 ||
            args.Length == 1 && !Enum.TryParse<Demo>(args[0], ignoreCase: true, out flavor))
        {
            Console.WriteLine();
            Console.WriteLine($"Provide a single argument to select a demo-mode (default: Calendar):");
            Console.WriteLine($"\n\t{string.Join("\n\t", Enum.GetValues<Demo>())}");
            Console.WriteLine();
            return;
        }

        var demo = demos[flavor].Invoke();

        await demo.InvokeAsync(new AgentStrategy(Agents.MonoAgent));
        await demo.InvokeAsync(new AgentStrategy(Agents.ManagerAgent));
    }
}
