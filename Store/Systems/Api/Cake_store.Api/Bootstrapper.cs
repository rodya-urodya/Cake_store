namespace Cake_store.Api;

using Cake_store.Services.Settings;
using Cake_store.Services.Logger;
using Cake_store.Context.Seeder;
using Cake_store.Api.Settings;
using Cake_store.Services.Products;
using Cake_store.Services.RabbitMq;
using Cake_store.Services.Actions;
using Cake_store.Services.UserAccount;

public static class Bootstrapper
{
    public static IServiceCollection RegisterServises (this IServiceCollection service, ConfigurationManager configuration)
    {
        service
            .AddMainSettings()
            .AddLogSettings()
            .AddSwaggerSettings()
            .AddIdentitySettings()
            .AddAppLogger()
            .AddDbSeeder()
            .AddApiSpecialSettings()
            .AddProductServise()
            .AddRabbitMq()
            .AddActions()
            .AddUserAccountService()
            ;

        return service;
    }
}
