namespace Microsoft.Microagents.Demos;

internal class TravelDemo : StrategyDemo
{
    public override string Objective =>
        """
        Book a getaway to hawaii for four nights next month.
        Pick any date that works for my calendar.
        I prefer Kona but any island is fine.
        """;
}
