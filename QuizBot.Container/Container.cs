using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using QuizBot.Repository;
using QuizBot.Repository.Contract;
using QuizBot.Service;
using QuizBot.Service.Contract;
using QuizBot.Telegram;
using QuizBot.Telegram.Contract;

namespace QuizBot.Container
{
    public sealed class Container
    {
        private static readonly Lazy<Container> lazy =
            new Lazy<Container>(() => new Container());

        public static AutofacServiceProvider Instance => lazy.Value._serviceProvider;

        private readonly AutofacServiceProvider _serviceProvider;

        private Container()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging();
            var containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(serviceCollection);

            var assemblies = Directory
                .EnumerateFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll", SearchOption.TopDirectoryOnly)
                .Where(filePath => Path.GetFileName(filePath).StartsWith("QuizBot"))
                .Select(Assembly.LoadFrom)
                .ToArray();
            containerBuilder.RegisterAssemblyTypes(assemblies).AsImplementedInterfaces();

            var container = containerBuilder.Build();
            _serviceProvider = new AutofacServiceProvider(container);
        }
    }
}