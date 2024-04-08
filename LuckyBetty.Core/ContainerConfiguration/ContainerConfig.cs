using LuckyBetty.Core.Commands.Contracts;
using LuckyBetty.Core.Contracts;
using LuckyBetty.Core.Providers.IO.Contracts;
using LuckyBetty.Core.Providers.IO.Implementation;
using LuckyBetty.Core.Services.Contracts;
using LuckyBetty.Core.Services.Implementation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LuckyBetty.Core.ContainerConfiguration;

public static class ContainerConfig
{
    public static IServiceProvider Configure()
    {
        var serviceCollection = new ServiceCollection();

        RegisterComponents(serviceCollection);

        return serviceCollection.BuildServiceProvider();
    }

    private static void RegisterComponents(IServiceCollection services)
    {
        services.AddSingleton<IEngine, Engine>();
        services.AddSingleton<IConsoleCleaner, ConsoleCleaner>();
        services.AddSingleton<IConsoleReader, ConsoleReader>();
        services.AddSingleton<IConsoleWriter, ConsoleWriter>();
        services.AddTransient<IInputProcessor, InputProcessor>();

        RegisterServices(services);
        RegisterCommands(services);
    }

    private static void RegisterServices(IServiceCollection services)
    {
        services.AddTransient<IGameService, GameService>();
        services.AddScoped<IWalletService, WalletService>();
    }

    private static void RegisterCommands(IServiceCollection services)
    {
        var coreAssembly = Assembly.GetExecutingAssembly();

        var commands = coreAssembly.GetTypes()
                                   .Where(type => !type.IsAbstract && type.GetInterfaces().Contains(typeof(ICommand)));

        foreach (var command in commands)
        {
            services.AddSingleton(command.GetInterfaces().First(), command);
        }
    }
}
