
using FluentValidation;
using HouseRent.Infra.SnowflakeIdGenerators;
using IdGen.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MMCourseStore.Framework.Behaviors.Logging;
using MMCourseStore.Framework.Behaviors.Validations;
using MMCourseStore.Framework.Services.DateTimeServices;
using MMCourseStore.Framework.Services.IdGeneratorServices;
using MMCourseStore.Framework.Services.UserInformation.Options;
using MMCourseStore.Framework.Services.UserInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using IdGen;
using Microsoft.AspNetCore.Builder;
using Serilog.Core;
using Serilog;
using Serilog.Exceptions;
using Serilog.Enrichers.Span;
using MMCourseStore.Framework.Services.Logging.Enrichers;

namespace MMCourseStore.Modules.DI;
public static class DependencyInjection
{
    public static IServiceCollection AddModularMonolithFramework(this IServiceCollection services,
                                                IConfiguration configuration, int idGeneratorId, List<Assembly> assembliesforScan)
    {
        services.AddHttpContextAccessor();
        services.AddTransient<IDateTimeProvider, DateTimeProvider>();

        services.AddIdGeneratorServices(idGeneratorId);

        services.AddWebUserInfoService(c =>
        {
            c.DefaultUserId = "-1";
        });



        services.AddValidatorsFromAssemblies(assembliesforScan);

        services.AddMediatR(c =>
        {
            c.RegisterServicesFromAssemblies([.. assembliesforScan]);
            c.AddOpenBehavior(typeof(LoggingBehavior<,>));
            c.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });
        return services;
    }


    private static IServiceCollection AddWebUserInfoService(this IServiceCollection services, Action<UserManagementOptions> setupAction)
    {
        services.Configure(setupAction);
        services.AddTransient<IUserInfoService, WebUserInfoService>();
        return services;
    }

    private static IServiceCollection AddIdGeneratorServices(this IServiceCollection services,int idGeneratorId)
    {
        services.AddIdGen(idGeneratorId);
        services.AddSingleton<Framework.Services.IdGeneratorServices.IIdGenerator<long>, SnowflakeIdGenerator>();
        return services;
    }

    
}
