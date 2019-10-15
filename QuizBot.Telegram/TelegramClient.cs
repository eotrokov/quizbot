using System;
using QuizBot.Model;
using QuizBot.Repository.Contract;
using QuizBot.Telegram.Contract;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;

namespace QuizBot.Telegram
{
    public class TelegramClient : ITelegramClient
    {
        /// <summary>
        /// Токен бота
        /// </summary>
        private readonly string _botToken = Environment.GetEnvironmentVariable("BOT_TOKEN");


        private static TelegramBotClient _client;
        private IUserRepository _userRepository;


        public TelegramClient(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _client = new TelegramBotClient(_botToken);
            _client.OnMessage += BotOnMessageReceived;
            _client.OnMessageEdited += BotOnMessageReceived;
            _client.StartReceiving();
            Console.ReadLine();
            _client.StopReceiving();
        }

        private async void BotOnMessageReceived(object sender, MessageEventArgs messageEventArgs)
        {
            var message = messageEventArgs.Message;
            var user = _userRepository.GetUserById(message.From.Id);
            if (user == null)
            {
                await _client.SendTextMessageAsync(message.Chat.Id, "Новый");
                _userRepository.SaveUser(new User
                {
                    Id = message.From.Id,
                    Name = message.From.Username
                        
                });
            }
            else
            {
                await _client.SendTextMessageAsync(message.Chat.Id, $"{user.Name} привет");
            }
        }
    }
}