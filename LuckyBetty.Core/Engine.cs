using LuckyBetty.Core.Contracts;
using LuckyBetty.Core.Providers.IO.Contracts;

namespace LuckyBetty.Core;

public sealed class Engine : IEngine
{
    private readonly IConsoleReader consoleReader;
    private readonly IConsoleWriter consoleWriter;
    private readonly IInputProcessor inputProcessor;

    public Engine(IConsoleReader consoleReader, IConsoleWriter consoleWriter, IInputProcessor inputProcessor)
    {
        this.consoleReader = consoleReader;
        this.consoleWriter = consoleWriter;
        this.inputProcessor = inputProcessor;
    }

    public void Run()
    {
        consoleWriter.WriteLineInBlue(Constants.LOGO);
        consoleWriter.WriteLine(Constants.WELCOME);
        consoleWriter.WriteLine(string.Empty);
        consoleWriter.WriteLine(Constants.HELP_SUGGESTION);
        consoleWriter.WriteLine(string.Empty);

        while (true)
        {
            consoleWriter.WriteLine(Constants.PROMPT);
            consoleWriter.Write(Constants.ORNAMENT);

            var input = consoleReader.ReadLine();

            if (input.ToLower().Trim() == Constants.Command.EXIT)
            {
                break;
            }

            var output = inputProcessor.Process(input);

            if (!string.IsNullOrEmpty(output))
            {
                consoleWriter.WriteLine(string.Empty);
                consoleWriter.WriteLine(output);
                consoleWriter.WriteLine(string.Empty);
            }

            consoleWriter.WriteLineInBlue(Constants.DELIMITER);
        }

        consoleWriter.WriteLineInBlue(Constants.DELIMITER);
        consoleWriter.WriteLine(Constants.GOODBYE);
        consoleWriter.WriteLineInBlue(Constants.DELIMITER);
    }
}
