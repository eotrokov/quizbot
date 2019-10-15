using System;
using Microsoft.Extensions.DependencyInjection;
using QuizBot.Telegram.Contract;


namespace QuizBot.App
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var s = QuizBot.Container.Container.Instance)
            {
                var f = s.GetService<ITelegramClient>();
               
            }
        }
    }
}