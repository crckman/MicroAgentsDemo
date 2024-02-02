namespace Microsoft.Microagents.Strategies;

internal abstract class Strategy
{
    protected const ConsoleColor ColorTrace = ConsoleColor.DarkGray;
    protected ConsoleColor ColorInput = ConsoleColor.Green;
    protected ConsoleColor ColorAssistant = ConsoleColor.Cyan;

    public abstract string Name { get; }

    public TextWriter? ResultWriter { get; set; }

    public abstract Task InvokeAsync(string inputMessage);

    protected void WriteLine(string message, ConsoleColor color)
    {
        Write(message, color);

        this.ResultWriter?.WriteLine();
        Console.WriteLine();
    }

    protected void Write(string message, ConsoleColor color)
    {
        var currentColor = Console.ForegroundColor;
        Console.ForegroundColor = color;

        this.ResultWriter?.Write(message);
        Console.Write(message);

        Console.ForegroundColor = currentColor;
    }
}
