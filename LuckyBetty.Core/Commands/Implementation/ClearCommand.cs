using LuckyBetty.Core.Attributes;
using LuckyBetty.Core.Commands.Contracts;
using LuckyBetty.Core.Providers.IO.Contracts;

namespace LuckyBetty.Core.Commands.Implementation;

[CommandInfo(Constants.Command.Description.CLEAR, Constants.Command.Usage.CLEAR, Constants.Command.Category.OTHER)]
public sealed class ClearCommand(IConsoleCleaner consoleCleaner) : ICommand
{
    public string Execute(IReadOnlyList<string> args)
    {
        consoleCleaner.Clear();

        return string.Empty;
    }
}
