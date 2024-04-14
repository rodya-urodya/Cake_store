namespace Cake_store.Worker;

using Cake_store.Services.RabbitMq;
using Microsoft.Extensions.DependencyInjection;
using Cake_store.Services.Logger;

public static class Bootstrapper
{
    public static IServiceCollection RegisterAppServices(this IServiceCollection services)
    {
        services
            .AddAppLogger()
            .AddRabbitMq()            
            ;

        services.AddSingleton<ITaskExecutor, TaskExecutor>();

        return services;
    }
}