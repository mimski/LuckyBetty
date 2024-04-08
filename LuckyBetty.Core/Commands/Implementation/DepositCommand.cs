using LuckyBetty.Core.Attributes;
using LuckyBetty.Core.Commands.Contracts;
using LuckyBetty.Core.Services.Contracts;

namespace LuckyBetty.Core.Commands.Implementation;

[CommandInfo(Constants.Command.Description.DEPOSIT, Constants.Command.Usage.DEPOSIT, Constants.Command.Category.WALLET)]
public class DepositCommand(IWalletService walletService) : ICommand
{
    public string Execute(IReadOnlyList<string> args)
    {
        if (args.Count != 1 || !decimal.TryParse(args[0], out decimal amount))
        {
            return $"{Constants.Command.INVALID_ARGUMENTS} Usage: {Constants.Command.Usage.DEPOSIT}";
        }

        var output = walletService.Deposit(amount);

        return output;
    }
}
