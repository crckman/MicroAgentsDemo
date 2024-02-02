namespace Microagents.Tools;

using Microsoft.SemanticKernel;
using System.ComponentModel;
using System.Text.Json;

public class Banking : DiagnosticPlugin
{
    private readonly Dictionary<string, BankAccount> accounts =
        new()
        {
            {"12340", new BankAccount("12340", "Checking", 110.32)},
            {"12359", new BankAccount("12359", "Savings", 2033.92)},
        };

    [KernelFunction]
    [Description("Get list of bank account ids.")]
    public string GetAccounts()
    {
        var result = accounts.Values.Select(a => a.Id).ToArray();

        return
            CaptureCall(
                nameof(GetAccounts),
                JsonSerializer.Serialize(result));
    }

    [KernelFunction]
    [Description("Get a bank account name.")]
    public string GetAccountName(string accountId)
    {
        accounts.TryGetValue(accountId, out var account);

        return
            CaptureCall(
                nameof(GetAccountName),
                JsonSerializer.Serialize(account?.Name ?? "Unknown account"),
                new()
                {
                    { nameof(accountId), accountId },
                });
    }

    [KernelFunction]
    [Description("Get a bank account balance.")]
    public string GetAccountBalance(string accountId)
    {
        accounts.TryGetValue(accountId, out var account);

        return
            CaptureCall(
                nameof(GetAccountBalance),
                JsonSerializer.Serialize(account?.Balance ?? 0),
                new()
                {
                    { nameof(accountId), accountId },
                });
    }

    [KernelFunction]
    [Description("Deposit an amount between two bank accounts.")]
    public string Deposit(string accountId, double amount)
    {
        bool isComplete = false;

        if (accounts.TryGetValue(accountId, out var account))
        {
            account.Balance += amount;
            isComplete = true;
        }

        return
            CaptureCall(
                nameof(Deposit),
                JsonSerializer.Serialize(isComplete),
                new()
                {
                    { nameof(accountId), accountId },
                    { nameof(amount), amount },
                });
    }

    [KernelFunction]
    [Description("Withdraw an amount between two bank accounts.")]
    public string Withdraw(string accountId, double amount)
    {
        bool isComplete = false;

        if (accounts.TryGetValue(accountId, out var account))
        {
            if (account.Balance > amount)
            {
                account.Balance -= amount;
                isComplete = true;
            }
        }

        return
            CaptureCall(
                nameof(Withdraw),
                JsonSerializer.Serialize(isComplete),
                new()
                {
                    { nameof(accountId), accountId },
                    { nameof(amount), amount },
                });
    }

    [KernelFunction]
    [Description("Transfer an amount between two bank accounts.")]
    public string Transfer(string fromAccountId, string toAccountId, double amount)
    {
        bool isComplete = false;

        if (accounts.TryGetValue(fromAccountId, out var fromAccount) &&
            accounts.TryGetValue(toAccountId, out var toAccount))
        {
            if (fromAccount.Balance > amount)
            {
                fromAccount.Balance -= amount;
                toAccount.Balance += amount;
                isComplete = true;
            }
        }

        return
            CaptureCall(
                nameof(Transfer),
                JsonSerializer.Serialize(isComplete),
                new()
                {
                    { nameof(fromAccountId), fromAccountId },
                    { nameof(toAccountId), toAccountId },
                    { nameof(amount), amount },
                });
    }

    private record BankAccount(
        string Id,
        string Name,
        double Balance)
    {
        public double Balance { get; set; } = Balance;
    }
}
