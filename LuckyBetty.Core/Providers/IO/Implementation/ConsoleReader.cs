using LuckyBetty.Core.Providers.IO.Contracts;

namespace LuckyBetty.Core.Providers.IO.Implementation;

public class ConsoleReader : IConsoleReader
{
    public string ReadLine()
    {
        return Console.ReadLine();
    }
}
