namespace Microagents.Demos;

using Microsoft.Microagents.Strategies;
using Microsoft.Microagents.Tools;
using System.Diagnostics;

internal abstract class StrategyDemo
{
    public abstract string Objective { get; }

    public async Task InvokeAsync(Strategy strategy)
    {
        DiagnosticPlugin.Reset();

        Console.WriteLine();
        Console.WriteLine();

        var timestamp = DateTime.Now;

        if (!Directory.Exists(Config.ResultPath))
        {
            Directory.CreateDirectory(Config.ResultPath);
        }

        using var fileWriter = strategy.ResultWriter = File.CreateText(Path.Combine(Config.ResultPath, $"{this.GetType().Name}-{strategy.Name}-{Config.ModelName}-{timestamp:yyMMdd-HHmmss}.txt"));
        var timer = Stopwatch.StartNew();
        try
        {
            await strategy.InvokeAsync(this.Objective);

            var duration = timer.Elapsed;

            WriteLine($"Duration: {duration}");

            foreach (var diagnostic in DiagnosticPlugin.Counts.OrderBy(kvp => kvp.Key))
            {
                WriteLine($"{diagnostic.Key} #{diagnostic.Value}");
            }

            fileWriter.WriteLine("=====================================");

            foreach (var diagnostic in DiagnosticPlugin.Traces)
            {
                fileWriter.WriteLine($"# {diagnostic.Function}");

                foreach (var parameter in diagnostic.Parameters)
                {
                    fileWriter.WriteLine($"  - {parameter.Key}:{parameter.Value}");
                }

                fileWriter.WriteLine($"  > {diagnostic.Value}");
            }

            void WriteLine(string message)
            {
                Console.WriteLine(message);
                fileWriter.WriteLine(message);
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine($"!!! FAILURE: {exception.Message}");
            fileWriter.WriteLine(exception);
        }
        finally
        {
            await Agents.DeleteAgentsAsync();
        }
    }
}
