using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MMCourseStore.Modules.Orders.Data;
using System.Reflection;

namespace MMCourseStore.Modules.DI;
public static class DependencyInjection
{
    public static IServiceCollection AddOrderModule(this IServiceCollection services,
                                                IConfiguration configuration, List<Assembly> assembliesforScan)
    {
        var connectionString =
                  configuration.GetConnectionString("OrderCnn")
                  ?? throw new ArgumentNullException("Connection String not found. check the name of connection string in configuration file");

        services.AddDbContext<OrderDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        assembliesforScan.Add(typeof(DependencyInjection).Assembly);
        return services;
    }
}
