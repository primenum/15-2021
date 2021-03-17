
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Exam.Q2.App
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Host build with Dependency injector, Logger, Configurations (Env variables + files)
            var host = HostBuilder();
            //Get logger
            var logger = ((ILoggerFactory)host.Services.GetService(typeof(ILoggerFactory))).CreateLogger<Program>();

            //get my application entry point
            var app = ((Application)host.Services.GetService(typeof(Application)));
            try
            {
                Console.WriteLine("CTRL+C to abort and exit");
                app.Run();
                await host.WaitForShutdownAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
            }

        }




        private static IHost HostBuilder()
        {
            string env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            if (string.IsNullOrEmpty(env))
                env = "Production";

            return Host.CreateDefaultBuilder()
                                .UseConsoleLifetime()
                                .UseEnvironment(env)
                                .ConfigureAppConfiguration((context, builder) =>
                                {

                                })
                                .ConfigureHostConfiguration(options =>
                                {
                                    BuildConfigurationOptions(options);
                                })
                                .ConfigureServices((hostContext, services) =>
                                {
                                    RegisterDIComponents(services, hostContext.Configuration);
                                })
                                .ConfigureLogging((context, options) =>
                                {
                                    options.ClearProviders();
                                    options.AddConsole();
                                    //optional logger implementation
                                    //options.AddNLog(context.Configuration);
                                })

                                .Build();

        }


        private static void BuildConfigurationOptions(IConfigurationBuilder configurationBuilder)
        {
            string env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            configurationBuilder
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
        }

        private static void RegisterDIComponents(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<Application>();
            services.AddRepositoryServices();
            services.AddFormatterServices();
        }

    }
}
