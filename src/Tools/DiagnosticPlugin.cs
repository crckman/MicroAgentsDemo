namespace Microsoft.Microagents.Tools;

public abstract class DiagnosticPlugin
{
    public static Dictionary<string, int> Counts { get; } = [];

    public static List<Diagnostic> Traces { get; } = [];

    public static void Reset()
    {
        Counts.Clear();
        Traces.Clear();
    }

    protected T CaptureCall<T>(
        string methodName,
        T returnValue,
        Dictionary<string, object?>? parameters = null)
    {
        var typeName = this.GetType().Name;

        Console.WriteLine($"# {typeName}.{methodName}");

        Counts.TryGetValue($"{typeName}.{methodName}", out var count);
        Counts[$"{typeName}.{methodName}"] = ++count;

        Traces.Add(new Diagnostic($"{typeName}.{methodName}", parameters, returnValue));

        if (parameters != null)
        {
            foreach (var parameter in parameters)
            {
                Console.WriteLine($"  - {parameter.Key}:{parameter.Value}");
            }
        }

        Console.WriteLine($"  > {returnValue}");

        return returnValue;
    }

    public class Diagnostic(string function, Dictionary<string, object?>? parameters, object? returnValue)
    {
        public string Function { get; } = function;

        public Dictionary<string, object?> Parameters = parameters ?? [];

        public Type Type => this.Value?.GetType() ?? typeof(object);

        public object? Value { get; } = returnValue;
    }
}
