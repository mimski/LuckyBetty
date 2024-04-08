using LuckyBetty.Core.Attributes;
using LuckyBetty.Core.Commands.Contracts;

namespace LuckyBetty.Core.Commands.Implementation;

[CommandInfo(Constants.Command.Description.RULES, Constants.Command.Usage.RULES, Constants.Command.Category.GAME)]
public sealed class RulesCommand : ICommand
{
    public string Execute(IReadOnlyList<string> args)
    {
        return Constants.GAME_RULES;
    }
}
