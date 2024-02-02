# MicroAgents Demo
This repo contains a demo app associated with the blog: [MicroAgents: Exploring Agentic Architecture with Microservices](https://devblogs.microsoft.com/semantic-kernel/microagents-exploring-agentic-architecture-with-microservices/) by Alex Chao & Chris Rickman.

## Goal

TBD

![A mono-agent](./.media/monoagents.png)

![A micro-agent](./.media/microagents.png)

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

TBD

