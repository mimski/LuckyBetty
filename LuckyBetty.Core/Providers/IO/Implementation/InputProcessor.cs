using LuckyBetty.Core.Commands.Contracts;
using LuckyBetty.Core.Providers.IO.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace LuckyBetty.Core.Providers.IO.Implementation;

public class InputProcessor(IServiceProvider serviceProvider) : IInputProcessor
{
    public string Process(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return Constants.HELP_SUGGESTION;
        }

        //if (input.ToLower().Trim().Equals(Constants.Command.EXIT))
        //{
        //    return Constants.GOODBYE;
        //}

        using (var scope = serviceProvider.CreateScope())
        {
            try
            {
                (string commandName, IReadOnlyList<string> args) = ParseInput(input);

                var commands = scope.ServiceProvider.GetServices<ICommand>();
                var command = commands.FirstOrDefault(command => string.Equals(command.GetType().Name, $"{commandName}Command", StringComparison.OrdinalIgnoreCase));

                if (command == null)
                {
                    return $"{Constants.NO_SUCH_COMMAND}: {commandName}\n{Constants.HELP_SUGGESTION}";
                }

                return command.Execute(args);
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }

                return " > " + ex.Message;
            }
        }
    }

    private (string commandName, IReadOnlyList<string> args) ParseInput(string input)
    {
        var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        return (parts[0], parts.Skip(1).ToList());
    }
}