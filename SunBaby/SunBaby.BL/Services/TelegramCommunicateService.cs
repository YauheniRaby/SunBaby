using Microsoft.Extensions.Options;
using SunBaby.BL.Configuration;
using SunBaby.BL.Services.Abstract;
using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace SunBaby.BL.Services
{
    public class TelegramCommunicateService : ITelegramCommunicateService
    {
        readonly ITelegramBotClient _botClient;
        readonly IOptions<CommandConfiguration> _commandConfiguration;

        public TelegramCommunicateService(ITelegramBotClient botClient, IOptions<CommandConfiguration> commandConfiguration)
        {
            _botClient = botClient;
            _commandConfiguration = commandConfiguration;
        }

        public Task<User> GetAboutMeAsync()
        {
            return _botClient.GetMeAsync();
        }
        public void SpotCommand(Message message)
        {
            if (message != null)
            {
                var config = _commandConfiguration.Value;
                switch (message.Text)
                {
                    case var value when value == config.Start:
                        break;
                    case var value when value == config.Orders:
                        break;
                    case var value when value == config.Catalog:
                        break;
                }
            }            
        }
    }
}
