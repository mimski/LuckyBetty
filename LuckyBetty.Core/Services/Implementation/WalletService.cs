using LuckyBetty.Core.Services.Contracts;

namespace LuckyBetty.Core.Services.Implementation;

public class WalletService : IWalletService
{
    private decimal balance;

    public WalletService()
    {
        balance = 0;
    }

    public string Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            return $"Deposit {Constants.AMOUNT_GREATER_THAN} {0:C}. {this.GetCurrentBalanceMessage()}";
        }

        balance += amount;

        return $"Your deposit of {amount:C} was successful. {this.GetCurrentBalanceMessage()}";
    }

    public string Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            return $"Withdrawal {Constants.AMOUNT_GREATER_THAN} {0:C}. {this.GetCurrentBalanceMessage()}";
        }

        if (balance >= amount)
        {
            balance -= amount;

            return $"You withdrawal of {amount:C} was successful. {this.GetCurrentBalanceMessage()}";
        }
        else
        {
            return this.GetInsufficientFundsMessage();
        }
    }

    public void UpdateBalance(decimal betAmount, decimal winAmount)
    {
        decimal newBalance = balance - betAmount + winAmount;

        if (newBalance < 0)
        {
            newBalance = 0;
        }

        balance = newBalance;
    }

    public decimal GetBalance()
    {
        return balance;
    }

    public string GetCurrentBalanceMessage()
    {
        return $"{Constants.CURRENT_BALANCE} {this.GetBalance():C}";
    }

    public string GetInsufficientFundsMessage()
    {
        return $"{Constants.NO_ENOUGH_MONEY} {this.GetCurrentBalanceMessage()}";
    }
}
