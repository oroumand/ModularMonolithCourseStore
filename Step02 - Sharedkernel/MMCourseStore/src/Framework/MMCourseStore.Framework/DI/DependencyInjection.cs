
using FluentValidation;
using HouseRent.Infra.SnowflakeIdGenerators;
using IdGen.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MMCourseStore.Framework.Behaviors.Logging;
using MMCourseStore.Framework.Behaviors.Validations;
using MMCourseStore.Framework.Services.DateTimeServices;
using MMCourseStore.Framework.Services.IdGeneratorServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MMCourseStore.Modules.DI;
public static class DependencyInjection
{
    public static IServiceCollection AddModularMonolithFramework(this IServiceCollection services,
                                                IConfiguration configuration, int idGeneratorId, List<Assembly> assembliesforScan)
    {
        services.AddTransient<IDateTimeProvider, DateTimeProvider>();
        services.AddIdGen(idGeneratorId);
        services.AddSingleton<IIdGenerator<long>, SnowflakeIdGenerator>();

        services.AddValidatorsFromAssemblies(assembliesforScan);
        
        services.AddMediatR(c =>
        {
            c.RegisterServicesFromAssemblies([.. assembliesforScan]);
            c.AddOpenBehavior(typeof(LoggingBehavior<,>));
            c.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });
        return services;
    }
}
