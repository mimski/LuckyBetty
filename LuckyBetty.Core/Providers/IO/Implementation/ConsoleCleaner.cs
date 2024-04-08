using LuckyBetty.Core.Providers.IO.Contracts;

namespace LuckyBetty.Core.Providers.IO.Implementation;

public class ConsoleCleaner : IConsoleCleaner
{
    public void Clear()
    {
        Console.Clear();
    }
}
