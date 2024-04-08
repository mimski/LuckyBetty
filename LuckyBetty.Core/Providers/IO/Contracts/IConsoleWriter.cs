namespace LuckyBetty.Core.Providers.IO.Contracts;

public interface IConsoleWriter
{
    void Write(string message);

    void WriteLine(string message);

    void WriteLineInBlue(string message);
}
