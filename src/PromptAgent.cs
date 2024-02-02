namespace Microsoft.Microagents;

using Microsoft.SemanticKernel;
using System.Diagnostics.CodeAnalysis;

public sealed class PromptAgent(Kernel kernel, KernelFunction function, string name, string? description = null)
    : KernelPlugin(name, description)
{
    public override int FunctionCount => 1;

    public KernelFunction Function { get;  } = function;

    public Kernel Kernel { get; } = kernel;

    public override IEnumerator<KernelFunction> GetEnumerator()
    {
        yield return this.Function;
    }

    public override bool TryGetFunction(string name, [NotNullWhen(true)] out KernelFunction? function)
    {
        function = null;

        if (this.Function.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
        {
            function = this.Function;
        }

        return function != null;
    }
}
