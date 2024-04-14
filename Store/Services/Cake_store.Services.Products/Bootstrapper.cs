namespace Cake_store.Services.Products;


using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static IServiceCollection AddProductServise(this IServiceCollection services)
    {
        return services
            .AddSingleton<iProductServise, iProductServise>();
    }
}