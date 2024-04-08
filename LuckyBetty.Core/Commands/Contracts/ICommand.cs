namespace LuckyBetty.Core.Commands.Contracts;

public interface ICommand
{
    string Execute(IReadOnlyList<string> args);
}
