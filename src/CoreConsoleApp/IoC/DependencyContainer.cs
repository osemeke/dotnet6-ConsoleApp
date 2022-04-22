using CoreConsoleApp.Data;
using CoreConsoleApp.Options;
using CoreConsoleApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Configuration;

namespace CoreConsoleApp.IoC
{
    internal static class DependencyContainer
    {
        internal static void ConfigureServices(IServiceCollection services)
        {
            IConfigurationRoot appsettings = GetAppSettings();

            services.AddTransient<OutputGenerator>();
            services.AddTransient<IGenerator, AlbumHtmlGeneration>();
            
            services.AddDbContext<SQLiteDbContext>();

            //services.AddDbContext<WaecDbContext>();

            services.AddDbContext<WaecDbContext>(options =>
                options.UseSqlServer(appsettings.GetSection("ConnectionStrings")["DefaultContext"]));

            // configure logging
            services.AddLogging(builder =>
            {
                builder.AddConsole();
                builder.AddDebug();
            });

            services.Configure<AppSettings>(appsettings.GetSection("Settings"));

        }

        private static IConfigurationRoot GetAppSettings()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .AddEnvironmentVariables()
                .Build();
        }

        public static IServiceProvider Configure()
        {
            var services = new ServiceCollection();

            // this is a convenience method from `Extensions.DependencyInjection` for distributed redis cache
            //services.AddDistributedRedisCache(option =>
            //{
            //    option.Configuration = "localhost:6379,allowAdmin=true";
            //    option.InstanceName = "foo-redis";
            //});

            // add your classes to the `services` container
            //services.AddSingleton<ICacheRepository, CacheRepository>();

            return services.BuildServiceProvider();
        }
    }
}
