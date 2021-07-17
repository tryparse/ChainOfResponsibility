using System;
using System.Linq;
using ChainOfResponsibility.Sandbox.Entities;
using ChainOfResponsibility.Sandbox.Mapping;
using ChainOfResponsibility.Sandbox.Runners;
using ChainOfResponsibility.Sandbox.Validation;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ChainOfResponsibility.Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();

            var simpleRunner = host.Services.GetServices<IRunner>()
                .First(x => x.GetType() == typeof(SimpleRunner));

            simpleRunner.Run();

            var corRunner = host.Services.GetServices<IRunner>()
                .First(x => x.GetType() == typeof(CORRunner));

            corRunner.Run();

            Console.WriteLine("done");
            Console.ReadKey(true);
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    services
                        .AddSingleton<IRunner, SimpleRunner>()
                        .AddSingleton<IRunner, CORRunner>()
                        .AddTransient<IValidator<Entity>, EntityValidator>()
                        .AddTransient<IValidator<DatabaseModel>, DatabaseModelValidator>()
                        .AddTransient<IMapper<FileData, Entity>, FileDataToEntityMapper>()
                        .AddTransient<IMapper<Entity, DatabaseModel>, EntityToDatabaseModelMapper>()
                );
        }
    }
}
