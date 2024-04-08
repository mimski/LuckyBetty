using LuckyBetty.Core.Attributes;
using LuckyBetty.Core.Commands.Contracts;
using System.Data;
using System.Reflection;
using System.Text;

namespace LuckyBetty.Core.Commands.Implementation;

[CommandInfo(Constants.Command.Description.HELP, Constants.Command.Usage.HELP, Constants.Command.Category.OTHER)]
public sealed class HelpCommand : ICommand
{
    public string Execute(IReadOnlyList<string> args)
    {
        var coreAssembly = Assembly.GetExecutingAssembly();

        var commandTypes = coreAssembly.GetTypes().Where(type => typeof(ICommand).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract);


        var sortedCommands = commandTypes.OrderBy(type =>
        {
            var commandInfo = type.GetCustomAttribute<CommandInfoAttribute>();
            return commandInfo != null ? commandInfo.Category : Constants.Command.Category.OTHER;
        }).ThenBy(type => type.Name);

        var output = new StringBuilder();

        foreach (var commandType in sortedCommands)
        {
            var commandInfo = commandType.GetCustomAttribute<CommandInfoAttribute>();
            if (commandInfo != null)
            {
                output.AppendLine($"{commandType.Name.ToLower().Replace("command", "")} - {commandInfo.Description}");
                output.AppendLine($"Usage: {commandInfo.Usage}");
                output.AppendLine();
            }
        }

        output.AppendLine($"{Constants.Command.EXIT} - {Constants.Command.Description.EXIT}");

        return output.ToString();
    }
}
