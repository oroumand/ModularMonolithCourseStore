using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MMCourseStore.Framework.Services.Logging.Enrichers;
using MMCourseStore.Framework.Services.Logging.Options;
using Serilog;
using Serilog.Core;
using Serilog.Enrichers.Span;
using Serilog.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMCourseStore.Framework.Services.Logging;
public static class SerilogExtensions
{
    public static void RunWithSerilogExceptionHandling(Action action, string startUpMessage = "Starting up", string exceptionMessage = "Unhandled exception", string shutdownMessage = "Shutdown complete")
    {
        Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateBootstrapLogger();
        Log.Information(startUpMessage);
        try
        {
            action();
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, exceptionMessage);
        }
        finally
        {
            Log.Information(shutdownMessage);
            Log.CloseAndFlush();
        }
    }
    public static WebApplicationBuilder AddSerilogServices(this WebApplicationBuilder builder, Action<SerilogApplicationEnricherOptions> setupAction)
    {
        builder.Services.Configure(setupAction);
        return AddServices(builder);
    }
    private static WebApplicationBuilder AddServices(WebApplicationBuilder builder)
    {

        List<ILogEventEnricher> logEventEnrichers = [];

        builder.Services.AddTransient<MMCourseStoreApplicaitonEnricher>();
        //builder.Services.AddTransient<MMCourseStoreUserInfoEnricher>();


        builder.Host.UseSerilog((ctx, services, lc) => {
            //logEventEnrichers.Add(services.GetRequiredService<MMCourseStoreUserInfoEnricher>());
            logEventEnrichers.Add(services.GetRequiredService<MMCourseStoreApplicaitonEnricher>());


            lc
            //.WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}")
            .Enrich.FromLogContext()
            .Enrich.With([.. logEventEnrichers])
            .Enrich.WithExceptionDetails()
            .Enrich.WithSpan()
            .ReadFrom.Configuration(ctx.Configuration);
        });
        return builder;
    }
}
