# MicroAgents Demo
This repo contains a demo app associated with the blog: [MicroAgents: Exploring Agentic Architecture with Microservices](https://devblogs.microsoft.com/semantic-kernel/microagents-exploring-agentic-architecture-with-microservices/) by Alex Chao & Chris Rickman.

## Goal

The *MicroAgent* concept is derived from *MicroServices* in the sense of coordinating loosely coupled microagents, each of which is paired to a specific api / domain.

#### Compared to a monolithic agent that manages a large tool set:
![A mono-agent](./.media/monoagents.png)

#### A microagent pattern delegates api interaction to specialized microagents:
![A micro-agent](./.media/microagents.png)

TBD: Open AI maximum is 128 tools for single agent.

TBD: Re-use

TBD: Context

## Setup
Configuration for the demo based on the following environment variables:

1. `OPENAI_KEY` - The OpenAI API key
1. `OPENAI_MODEL` - The target transformer model (defaults to `gpt-4-1106-preview`)
1. `RESULT_PATH` - The output path for writing results (defaults to `./results`)
 
Only `OPENAI_KEY` is required.  Example (PowerShell):

```powershell
 $Env:OPENAI_KEY='sk-000000000000000000000000000000000000000000000000'
```

## Execution
The demo takes a single parameter, which is the name of the demo to run:

- Calendar
- Banking
- Travel

Each demo run on both a *mono* and *micro* agent architecture, for comparison.

Example:

```cmd
cd src
dotnet run Travel
```

## Results

To validate the the overall process, the `Calendar` demo was ran repeatedly for either agent type with the following result:

|Agent|Completion|Attempts|Success%|Min. Duration|Avg. Duration|Max. Duration|
|---|---|---|---|---|---|---|
|Mono|11|45|76%|15.52s|22.81s|36.42s|
|Micro|5|45|89%|17.93s|35.12s|70.14s|

> The `Calendar` demo is a simple bench mark that utilizes two tools from the `Calendar API`:
> 1. Call tool to get current date.
> 1. Compute the dates for "next month"
> 1. Call tool to retrieve the list of next month's the calendar events
> 1. Identify openings on calendar for 5 day vacation

The microagent approach shows a higher success rate but also larger latencies.

Looking into the latency differences shows  the microagent approach results in additional POST requests.  Because the demo is based on the *Open AI Assistant API (beta)*, additional processing around `thread`, `message`, and `run` creation (as opposed to model processing) account for much of the difference in latency.