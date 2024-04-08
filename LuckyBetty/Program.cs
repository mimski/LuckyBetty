using LuckyBetty.Core.ContainerConfiguration;
using LuckyBetty.Core.Contracts;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = ContainerConfig.Configure();

using (var scope = serviceProvider.CreateScope())
{
    var engine = scope.ServiceProvider.GetRequiredService<IEngine>();
    engine.Run();
}