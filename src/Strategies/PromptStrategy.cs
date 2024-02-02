namespace Microagents.Strategies;

using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;

internal sealed class PromptStrategy(PromptAgent agent) : Strategy
{
    public PromptAgent Agent { get; } = agent;

    public override string Name => this.Agent.Name;

    public override async Task InvokeAsync(string inputMessage)
    {
        WriteLine($"Agent: {Agent.Name}", ColorInput);
        WriteLine($"Model: {Config.ModelName}", ColorInput);
        WriteLine($"Objective: {inputMessage}", ColorInput);

        var toolSettings =
            new OpenAIPromptExecutionSettings()
            {
                ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions
            };

        WriteLine("=====================================", ColorTrace);

        var arguments =
            new KernelArguments(toolSettings)
            {
                { "input", inputMessage },
            };

        var result = await this.Agent.Function.InvokeAsync(this.Agent.Kernel, arguments).ConfigureAwait(false);
        WriteLine($"# {result.GetValue<ChatMessageContent>()!.Content}", ColorAssistant);

        WriteLine("=====================================", ColorTrace);
    }
}
