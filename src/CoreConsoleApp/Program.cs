using CoreConsoleApp.Data;
using CoreConsoleApp.IoC;
using CoreConsoleApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

public class Program
{
    static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        host.Services
            .GetRequiredService<OutputGenerator>()
            .RunJobs();
    }

    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                DependencyContainer.ConfigureServices(services);
            });
    }
}



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

/*
 * using service = ServiceCollections -> ServiceProvider -> GetService<>()
 * 
class Program
{
    static void Main(string[] args)
    {
        var services = new ServiceCollection();
        ConfigureServices(services);
        services
            .AddSingleton<Executor,Executor>()
            .BuildServiceProvider()
            .GetService<Executor>()
            .Execute();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services
            .AddSingleton<ITest, Test>();
    }
}

public class Executor
{
    private readonly ITest _test;

    public Executor(ITest test)
    {
        _test = test;
    }

    public void Execute()
    {
        _test.DoSomething();
    }
}
*/