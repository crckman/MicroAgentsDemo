namespace Microagents.Strategies;

using Microsoft.SemanticKernel.Experimental.Agents;

internal sealed class AgentStrategy(IAgent agent) : Strategy
{
    public IAgent Agent { get; } = agent;

    public override string Name => this.Agent.Name ?? string.Empty;

    public override async Task InvokeAsync(string inputMessage)
    {
        WriteLine($"Agent: {this.Agent.Name}", ColorInput);
        WriteLine($"Model: {this.Agent.Model}", ColorInput);
        WriteLine($"Objective: {inputMessage}", ColorInput);

        var thread = await this.Agent.NewThreadAsync();

        WriteLine("=====================================", ColorTrace);
        WriteLine($"[{thread.Id}]", ColorTrace);

        try
        {
            await foreach (var responseMessage in thread.InvokeAsync(this.Agent, inputMessage))
            {
                WriteLine($"[{responseMessage.Id}]", ColorTrace);
                WriteLine($"# {responseMessage.Role}: {responseMessage.Content}", ColorAssistant);
            }
        }
        finally
        {
            WriteLine("=====================================", ColorTrace);
            await thread.DeleteAsync();
        }
    }
}
