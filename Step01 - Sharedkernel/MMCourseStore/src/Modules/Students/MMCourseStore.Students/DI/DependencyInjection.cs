using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using MMCourseStore.Modules.Students.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MMCourseStore.Modules.DI;
public static class DependencyInjection
{
    public static IServiceCollection AddStudentModule(this IServiceCollection services,
                                                IConfiguration configuration, List<Assembly> assembliesforScan)
    {
        var connectionString =
                  configuration.GetConnectionString("StudentCnn")
                  ?? throw new ArgumentNullException("Connection String not found. check the name of connection string in configuration file");

        services.AddDbContext<StudentDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        assembliesforScan.Add(typeof(DependencyInjection).Assembly);
        return services;
    }
}
