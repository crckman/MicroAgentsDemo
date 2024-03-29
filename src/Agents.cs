﻿namespace Microagents;

using Microagents.Tools;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Experimental.Agents;
using System.Collections.Generic;

public static class Agents
{
    private static readonly Dictionary<string, IAgent> agents = [];

    /// <summary>
    /// Manager/micro-agents using Open AI Assistant API.
    /// </summary>
    public static IAgent ManagerAgent =>
        GetManagerAgent(
            nameof(ManagerAgent),
            "Solve the given objective working with agents by providing complete and precise instructions.");

    /// <summary>
    /// Single agent using Open AI Assistant API.
    /// </summary>
    public static IAgent MonoAgent =>
        GetMonoAgent(
            nameof(MonoAgent),
            "Solve the given objective with the provided tools and available data.");

    /// <summary>
    /// Single agents using only LLM (no Assistant API).
    /// </summary>
    public static PromptAgent MonoPrompt =>
        CreateMonoPrompt(
            nameof(MonoPrompt),
            "Solve the given objective with the provided tools and available data.");

    public static async Task DeleteAgentsAsync()
    {
        foreach (var agent in agents.Values)
        {
            try
            {
                await agent.DeleteAsync();
            }
            catch
            {
                Console.WriteLine($"!!! FAILURE - Deleting agent {agent.Id} ({agent.Name})");
            }
        }

        agents.Clear();
    }

    private static IEnumerable<IAgent> GetAgents()
    {
        yield return
            GetMicroAgent<Airline>(
                "FlightAgent",
                "Provide airline flight information using only the provided tools.",
                "An agent that provides airline flight information");

        yield return
            GetMicroAgent<AnimalSounds>(
                "AnimalSoundAgent",
                "Provide the sounds made be certain animals.",
                "An agent that sounds made be certain animals");

        yield return
            GetMicroAgent<Banking>(
                "BankAgent",
                "Provide bank account information and transactions.",
                "An agent that acts as a banker.");

        yield return
            GetMicroAgent<Calendar>(
                "CalendarAgent",
                "Manage the calendar using the provided tools and provide precise and accurate information.",
                "An agent that manages the calendar.");

        yield return
            GetMicroAgent<Location>(
                "LocationAgent",
                "Provide geographic location information using only the provided tools.",
                "An agent that provides location information and about the user.");

        yield return
            GetMicroAgent<Translator>(
                "TranslatorAgent",
                "You are a translator that specializes in translating english phrases into other languages",
                "An agent that translates english phrases into other languages.");

        yield return
            GetMicroAgent<Travel>(
                "TravelAgent",
                "You are a travel agent that can list and book airline flights only when both origin and destination are explicitly defined.  Determine airport codes as needed using your knowledge.  Don't forget to consider return flights.",
                "An agent that provides information on available airline flights and also can book flights.  This agent does not know the location of your home and must always be told both the origin and destination.");

        yield return
            GetMicroAgent<Weather>(
                "WeatherAgent",
                "You provide weather information only.",
                "An agent that provides information on weather for a specific location.");
    }

    public static IEnumerable<KernelPlugin> GetPlugins()
    {
        yield return GetPlugin<Airline>();
        yield return GetPlugin<AnimalSounds>();
        yield return GetPlugin<Banking>();
        yield return GetPlugin<Calendar>();
        yield return GetPlugin<Location>();
        yield return GetPlugin<Translator>();
        yield return GetPlugin<Travel>();
        yield return GetPlugin<Weather>();
    }

    private static IAgent GetManagerAgent(
        string agentName,
        string agentInstructions)
    {
        if (!agents.TryGetValue(agentName, out var agent))
        {
            agent =
                CreateAgent(
                    agentName,
                    agentInstructions,
                    agentDescription: null,
                    GetAgents().Select(a => a.AsPlugin()).ToArray());
        }

        return agent;
    }

    private static IAgent GetMonoAgent(
        string agentName,
        string agentInstructions)
    {
        if (!agents.TryGetValue(agentName, out var agent))
        {
            agent =
                CreateAgent(
                    agentName,
                    agentInstructions,
                    agentDescription: null,
                    GetPlugins().ToArray());
        }

        return agent;
    }

    private static PromptAgent CreateMonoPrompt(
        string agentName,
        string agentInstructions)
    {
        return
            CreatePrompt(
                agentName,
                agentInstructions,
                agentDescription: null,
                GetPlugins().ToArray());
    }

    private static KernelPlugin GetPlugin<T>() where T : DiagnosticPlugin, new()
    {
        var tool = new T();

        var plugin = KernelPluginFactory.CreateFromObject(tool);

        return plugin;
    }

    private static PromptAgent CreateMicroPrompt<T>(
        string agentName,
        string agentInstructions,
        string agentDescription)
        where T : DiagnosticPlugin, new()
    {
        return
            CreatePrompt(
                agentName,
                agentInstructions,
                agentDescription,
                GetPlugin<T>());
    }

    private static PromptAgent CreatePrompt(
        string agentName,
        string agentInstructions,
        string? agentDescription = null,
        params KernelPlugin[] plugins)
    {
        string chatPrompt =
            @$"<message role=""system"">{agentInstructions}</message>\n" +
            @"<message role=""user"">{{$input}}</message>";

        var function =
            KernelFunctionFactory.CreateFromPrompt(
                chatPrompt,
                functionName: agentName,
                description: agentDescription);

        var builder =
            Kernel.CreateBuilder()
                .AddOpenAIChatCompletion(Config.ModelName, Config.ApiKey);

        foreach (var plugin in plugins)
        {
            builder.Plugins.Add(plugin);
        }

        var kernel = builder.Build();

        return new PromptAgent(kernel, function, agentName, agentDescription);
    }

    private static IAgent GetMicroAgent<T>(
        string agentName,
        string agentInstructions,
        string? agentDescription = null)
        where T : DiagnosticPlugin, new()
    {
        if (!agents.TryGetValue(agentName, out var agent))
        {
            agent = CreateAgent(agentName, agentInstructions, agentDescription, GetPlugin<T>());
        }

        return agent;
    }

    private static IAgent GetAgent(
        string agentName,
        string agentInstructions,
        string? agentDescription = null,
        params KernelPlugin[] plugins)
    {
        if (!agents.TryGetValue(agentName, out var agent))
        {
            agent = CreateAgent(agentName, agentInstructions, agentDescription, plugins);
        }

        return agent;
    }

    private static IAgent CreateAgent(
        string agentName,
        string agentInstructions,
        string? agentDescription = null,
        params KernelPlugin[] plugins)
    {
        return
            agents[agentName] =
            new AgentBuilder()
                .WithOpenAIChatCompletion(Config.ModelName, Config.ApiKey)
                .WithName(agentName)
                .WithInstructions(agentInstructions)
                .WithDescription(agentDescription)
                .WithPlugins(plugins)
                .BuildAsync()
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();
    }
}
