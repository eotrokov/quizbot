using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using QuizBot.Model;
using QuizBot.Repository.Contract;
using QuizBot.Service.Contract;
using QuizBot.Telegram.Contract;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.ReplyMarkups;

namespace QuizBot.Telegram
{
    public class TelegramClient : ITelegramClient
    {
        /// <summary>
        /// Токен бота
        /// </summary>
        private readonly string _botToken = Environment.GetEnvironmentVariable("BOT_TOKEN");


        private static TelegramBotClient _client;
        private readonly IUserService _userService;
        private readonly IQuestionService _questionService;


        public TelegramClient(IUserService userService, IQuestionService questionService)
        {
            _userService = userService;
            _questionService = questionService;
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
            var user = _userService.GetUserById(message.From.Id);
            if (user == null)
            {
                await _client.SendTextMessageAsync(message.Chat.Id, "Новый");
                _userService.SaveUser(new User
                {
                    Id = message.From.Id,
                    Name = message.From.Username
                });
            }
            else
            {
                var (t, keyboardMarkup) = Get();
                await _client.SendTextMessageAsync(message.Chat.Id, t, ParseMode.Markdown, replyMarkup: keyboardMarkup);
            }
        }

        private (string, ReplyKeyboardMarkup) Get()
        {
            var question = _questionService.GetQuestion();
            var answers = SplitList(question.Answers.Select(c => c.Title).ToList(), 2).ToArray();

            var buttons = answers.Select(g1 => g1.Select(g2 => new KeyboardButton(g2)));
            var replyMarkup = new ReplyKeyboardMarkup(buttons);
            return (question.Title, replyMarkup);
        }

        public static IEnumerable<List<T>> SplitList<T>(List<T> locations, int nSize = 30)
        {
            for (var i = 0; i < locations.Count; i += nSize)
            {
                yield return locations.GetRange(i, Math.Min(nSize, locations.Count - i));
            }
        }
    }
}