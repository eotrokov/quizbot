using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using QuizBot.Repository;
using QuizBot.Repository.Contract;
using QuizBot.Telegram;
using QuizBot.Telegram.Contract;

namespace QuizBot.Container
{
    public sealed class Container
    {
        private static readonly Lazy<Container> lazy =
            new Lazy<Container>(() => new Container());

        public static AutofacServiceProvider Instance => lazy.Value._serviceProvider;

        private AutofacServiceProvider _serviceProvider;

        private Container()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging();
            var containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(serviceCollection);
            containerBuilder.RegisterType<TelegramClient>().As<ITelegramClient>().SingleInstance();
            containerBuilder.RegisterType<UserRepository>().As<IUserRepository>().SingleInstance();
            var container = containerBuilder.Build();
            _serviceProvider = new AutofacServiceProvider(container);
        }
    }
}