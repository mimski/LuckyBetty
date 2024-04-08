namespace LuckyBetty.Core.Services.Contracts;

public interface IWalletService
{
    string Deposit(decimal amount);

    string Withdraw(decimal amount);

    void UpdateBalance(decimal betAmount, decimal winAmount);

    decimal GetBalance();

    string GetCurrentBalanceMessage();

    public string GetInsufficientFundsMessage();
}
