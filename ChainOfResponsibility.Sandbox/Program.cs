using System;
using ChainOfResponsibility.Sandbox.Entities;
using ChainOfResponsibility.Sandbox.Mapping;
using ChainOfResponsibility.Sandbox.Runners;
using ChainOfResponsibility.Sandbox.Validation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ChainOfResponsibility.Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();

            var runner = host.Services.GetRequiredService<IRunner>();

            runner.Run();

            Console.WriteLine("done");
            Console.ReadKey(true);
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    services
                        .AddSingleton<IRunner, CORRunner>()
                        .AddTransient<IValidator<Entity>, CommonValidator<Entity>>()
                        .AddTransient<IValidator<DatabaseModel>, CommonValidator<DatabaseModel>>()
                        .AddTransient<IMapper<FileData, Entity>, FileDataToEntityMapper>()
                        .AddTransient<IMapper<Entity, DatabaseModel>, EntityToDatabaseModelMapper>()
                );
        }
    }
}
