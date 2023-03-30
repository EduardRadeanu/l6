using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Tap.Solid.Dip.Services;

using IHost host = Host.CreateDefaultBuilder(args)
                        .ConfigureServices((_, services) =>
                            services.AddTransient<IReportService, ReportService>()
                            //@Students: Please make use of the code below to configure your Dependency injection, for Exercise 5 - DIP
                            //.AddTransient<IYourInterface, YourClass>()
                            //.AddTransient<IOtherInterface, YourOtherClass>()
                            )
                        .Build();

InvokeGenerateReportForExerciseFive(host.Services);

await host.RunAsync();

static void InvokeGenerateReportForExerciseFive(IServiceProvider services)
{
    using IServiceScope serviceScope = services.CreateScope();
    IServiceProvider provider = serviceScope.ServiceProvider;

    Console.WriteLine("This console app is used strictly for Exercice 5");
    Console.WriteLine();
    var reportService = provider.GetRequiredService<IReportService>();
    reportService.GenerateReport();

    Console.WriteLine();
}