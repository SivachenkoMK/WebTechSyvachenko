using OnlineShop.Application.Configurations;
using OnlineShop.Application.Models;
using OnlineShop.Application.Repositories;
using OnlineShop.Application.Services;
using OnlineShop.Controllers;
using OnlineShop.Domain.Models;
using OnlineShop.Domain.Services;

namespace OnlineShop.Application;

public static class ServicesRegistry
{
    public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions<BlobStorageConfiguration>().Bind(configuration.GetSection(nameof(BlobStorageConfiguration)));
        services.AddOptions<MapConfiguration>().Bind(configuration.GetSection(nameof(MapConfiguration)));
        services.AddOptions<SearchConfiguration>().Bind(configuration.GetSection(nameof(SearchConfiguration)));

        services.AddHttpClient(Routes.Privat24);

        services.AddScoped<Privat24Service>();
        services.AddScoped<IFilteringOptions, FilteringOptions>();
        services.AddScoped<IRepository<Dish>, DishRepository>();
        services.AddScoped<IRepository<Review>, ReviewRepository>();
        services.AddScoped<IRepository<Category>, CategoryRepository>();
        services.AddScoped<IRepository<Photo>, PhotoRepository>();
        services.AddScoped<IRepository<Restaurant>, RestaurantRepository>();
        services.AddScoped<FileService>();
        services.AddScoped<DishService>();

        return services;
    }
}