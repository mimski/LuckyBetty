using LuckyBetty.Core.Models;
using LuckyBetty.Core.Services.Contracts;

namespace LuckyBetty.Core.Services.Implementation;

public class GameService : IGameService
{
    public GameModel Play(decimal betAmount)
    {
        var game = new GameModel
        {
            BetAmount = betAmount,
        };

        if (betAmount < 1 || betAmount > 10)
        {
            game.ResultMessage = "Bet amount must be between $1 and $10.";
            game.WinnedAmount = 0;
            game.BetAmount = 0;

            return game;
        }

        var randomNumber = new Random().Next(1, 101); // Generate a random number between 1 and 100

        if (randomNumber <= 50) // 50% chance of losing
        {
            game.WinnedAmount = 0;
            game.ResultMessage = Constants.NO_WIN;
        }
        else if (randomNumber <= 90) // 40% chance of winning up to 2x the bet amount
        {
            game.WinnedAmount = Math.Round(betAmount * (decimal)(1 + new Random().NextDouble()), 2);
            game.ResultMessage = $"{Constants.WIN} {game.WinnedAmount:C}!";
        }
        else // 10% chance of winning between 2x and 10x the bet amount
        {
            game.WinnedAmount = Math.Round(betAmount * (decimal)(2 + (new Random().NextDouble() * 8)), 2);
            game.ResultMessage = $"{Constants.WIN} {game.WinnedAmount:C}!";
        }

        return game;
    }
}