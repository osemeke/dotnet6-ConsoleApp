using CoreConsoleApp.IoC;
using CoreConsoleApp.Services;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    static void Main(string[] args)
    {
        var services = new ServiceCollection();
        DependencyContainer.ConfigureServices(services);
        var serviceProvider = services.BuildServiceProvider();
        var outputGenerator = serviceProvider.GetService<OutputGenerator>();

        if (outputGenerator is null) throw new ArgumentNullException(nameof(outputGenerator));

        outputGenerator.RunJobs();
    }
}

// above is using service = ServiceCollections -> ServiceProvider -> GetService<>()
// see below for option B

//using CoreConsoleApp.Data;
//using CoreConsoleApp.IoC;
//using CoreConsoleApp.Services;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using Microsoft.Extensions.Logging;

//public class Program
//{
//    static void Main(string[] args)
//    {
//        var host = CreateHostBuilder(args).Build();
//        host.Services
//            .GetRequiredService<OutputGenerator>()
//            .RunJobs();
//    }

//    private static IHostBuilder CreateHostBuilder(string[] args)
//    {
//        return Host.CreateDefaultBuilder(args)
//            .ConfigureServices(services =>
//            {
//                DependencyContainer.ConfigureServices(services);
//            });
//    }
//}



/*
 * microsoft website 
 * 
 * public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddHostedService<Worker>();
            });
}*/

