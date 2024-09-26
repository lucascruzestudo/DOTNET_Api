using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace WebApi;

public static class DependencyInjection
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("Postgres")));

        var redisConnectionString = configuration.GetSection("Redis")["Connection"];
        if (string.IsNullOrEmpty(redisConnectionString))
        {
            throw new InvalidOperationException("Redis connection string is not configured.");
        }
        
        services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(redisConnectionString));

        var rabbitMqConnectionString = configuration.GetSection("RabbitMQ")["Connection"];
        if (string.IsNullOrEmpty(rabbitMqConnectionString))
        {
            throw new InvalidOperationException("RabbitMQ connection string is not configured.");
        }

    }
}
