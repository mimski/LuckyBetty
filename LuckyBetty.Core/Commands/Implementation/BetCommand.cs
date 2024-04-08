using LuckyBetty.Core.Attributes;
using LuckyBetty.Core.Commands.Contracts;
using LuckyBetty.Core.Services.Contracts;

namespace LuckyBetty.Core.Commands.Implementation;

[CommandInfo(Constants.Command.Description.BET, Constants.Command.Usage.BET, Constants.Command.Category.GAME)]
public class BetCommand : ICommand
{
    private readonly IGameService gameService;
    private readonly IWalletService walletService;

    public BetCommand(IGameService gameService, IWalletService walletService)
    {
        this.gameService = gameService;
        this.walletService = walletService;
    }

    public string Execute(IReadOnlyList<string> args)
    {
        if (args.Count != 1 || !decimal.TryParse(args[0], out decimal betAmount))
        {
            return $"{Constants.Command.INVALID_ARGUMENTS} Usage: {Constants.Command.Usage.BET}";
        }

        if (betAmount <= 0)
        {
            return $"Bet {Constants.AMOUNT_GREATER_THAN} {0:C}";
        }

        var currentBalance = this.walletService.GetBalance();

        if (betAmount > currentBalance)
        {
            return this.walletService.GetInsufficientFundsMessage();
        }

        var game = this.gameService.Play(betAmount);

        this.walletService.UpdateBalance(game.BetAmount, game.WinnedAmount);

        var output = $"{game.ResultMessage}\n{this.walletService.GetCurrentBalanceMessage()}";

        return output;
    }
}
