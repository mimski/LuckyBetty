using LuckyBetty.Core.Attributes;
using LuckyBetty.Core.Commands.Contracts;
using LuckyBetty.Core.Services.Contracts;

namespace LuckyBetty.Core.Commands.Implementation;

[CommandInfo(Constants.Command.Description.WITHDRAW, Constants.Command.Usage.WITHDRAW, Constants.Command.Category.WALLET)]
public class WithdrawCommand(IWalletService walletService) : ICommand
{
    public string Execute(IReadOnlyList<string> args)
    {
        if (args.Count != 1 || !decimal.TryParse(args[0], out decimal amount))
        {
            return $"{Constants.Command.INVALID_ARGUMENTS} Usage: {Constants.Command.Usage.WITHDRAW}";
        }

        var output = walletService.Withdraw(amount);

        return output;
    }
}
