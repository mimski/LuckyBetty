using LuckyBetty.Core.Models;
namespace LuckyBetty.Core.Services.Contracts;

public interface IGameService
{
    GameModel Play(decimal betAmount);
}
