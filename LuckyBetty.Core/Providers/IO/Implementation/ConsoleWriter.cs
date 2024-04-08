using LuckyBetty.Core.Providers.IO.Contracts;

namespace LuckyBetty.Core.Providers.IO.Implementation;

public class ConsoleWriter : IConsoleWriter
{
    public void Write(string message)
    {
        Console.Write(message);
    }

    public void WriteLine(string message)
    {
        Console.WriteLine(message);
    }

    public void WriteLineInBlue(string message)
    {
        if (message.Length != 0)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
