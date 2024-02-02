namespace Microsoft.Microagents.Demos;

internal class BankingDemo : StrategyDemo
{
    public override string Objective =>
        """
        Transfer $250 to my checking account if its less than $200.
        """;
}
