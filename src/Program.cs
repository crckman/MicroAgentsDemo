namespace Microsoft.Microagents.Demo;

using Microsoft.Microagents;
using Microsoft.Microagents.Demos;
using Microsoft.Microagents.Strategies;
using System.Dynamic;

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

        if (args.Length > 1)
        {
            Console.WriteLine(string.Join(", ", Enum.GetValues<Demo>()));
            return;
        }
        else if (args.Length == 1)
        {
            Enum.TryParse<Demo>(args[0], ignoreCase: true, out flavor);
        }

        var demo = demos[flavor].Invoke();

        await RunDemoAsync(new PromptStrategy(Agents.MonoPrompt));
        //await RunDemoAsync(new PromptStrategy(Agents.ManagerPrompt)); // $$$
        await RunDemoAsync(new AgentStrategy(Agents.ManagerAgent)); 
        await RunDemoAsync(new AgentStrategy(Agents.MonoAgent));

        Task RunDemoAsync(Strategy strategy) =>
            demo.InvokeAsync(strategy);
    }
}
