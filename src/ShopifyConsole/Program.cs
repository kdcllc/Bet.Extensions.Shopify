using System;
using System.Reflection;

using Bet.Extensions.Shopify.Abstractions.Options;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Serilog;
using Serilog.Events;
using Serilog.Sinks.AzureAnalytics;

using ShopifyConsole;

[assembly: UserSecretsId("f92d0b57-7961-4d28-a30d-9eb94c6abf7f")]

// Start our smart AppHost
AppHost.Start(args, Assembly.GetEntryAssembly()?.GetName().Name);

// Create a Serilog Logger
Log.Logger = AppHost.CreateSerilogLogger(
    (logger, configuration, env) =>
    {
        if (!string.IsNullOrEmpty(configuration["AzureLogAnalytics:WorkspaceId"])
        && !string.IsNullOrEmpty(configuration["AzureLogAnalytics:AuthenticationId"]))
        {
            logger.WriteTo.AzureAnalytics(
                configuration["AzureLogAnalytics:WorkspaceId"],
                configuration["AzureLogAnalytics:AuthenticationId"],
                new ConfigurationSettings
                {
                    Flatten = false,
                    LogName = $"{env.ApplicationName}{env.EnvironmentName}",
                    BufferSize = 1,
                    BatchSize = 1
                },
                restrictedToMinimumLevel: LogEventLevel.Information);
        }
    });

try
{
    Log.Information("Starting AppHost");

    using var host = AppHost
                    .CreateHostBuilder()
                    .ConfigureHostConfiguration((builder) => builder.AddUserSecrets(Assembly.GetExecutingAssembly()))
                    .ConfigureServices(ConsoleServiceCollectionExtensions.ConfigureServices)
                    .Build();

    await host.StartAsync();

    var result = await host.ExecuteAsync(async m => await m.RunAsync());

    await host.StopAsync();

    Log.Information("AppHost Stopped");

    return result;
}
catch (Exception ex)
{
    Log.Fatal(ex, "AppHost terminated unexpectedly");

    return 1;
}
finally
{
    Log.CloseAndFlush();
}
