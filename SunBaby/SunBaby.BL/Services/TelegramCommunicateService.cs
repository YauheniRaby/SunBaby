﻿using Microsoft.Extensions.Options;
using SunBaby.BL.Configuration;
using SunBaby.BL.Services.Abstract;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace SunBaby.BL.Services
{
    public class TelegramCommunicateService : ITelegramCommunicateService
    {
        readonly ITelegramBotClient _botClient;
        readonly IOptionsMonitor<CommandConfiguration> _commandConfiguration;
        readonly IOptionsMonitor<MessageConfiguration> _messageConfiguration;
        readonly IToyService _toyService;
        readonly IOrderService _orderService;
        readonly IUserService _userService;

        public TelegramCommunicateService(
            ITelegramBotClient botClient, 
            IOptionsMonitor<CommandConfiguration> commandConfiguration, 
            IOptionsMonitor<MessageConfiguration> messageConfiguration,
            IToyService toyService, 
            IOrderService orderService, 
            IUserService userService)
        {
            _botClient = botClient;
            _commandConfiguration = commandConfiguration;
            _messageConfiguration = messageConfiguration;
            _toyService = toyService;
            _orderService = orderService;
            _userService = userService;
        }

        public Task<User> GetAboutMeAsync()
        {
            return _botClient.GetMeAsync();
        }
        public async Task SpotCommand(Message message)
        {
            if (message != null)
            {
                var config = _commandConfiguration.CurrentValue;
                switch (message.Text)
                {
                    case var value when value == "/setdb":
                        _userService.AddUser();
                        _toyService.AddToy();
                        _orderService.AddOrder();
                        break;                      
                    case var value when value == config.Start:
                        await SendPrimaryGreeting(message.Chat);
                        break;
                    case var value when value == config.Orders:
                        break;
                    case var value when value == config.Catalog:
                        break;
                }
            }            
        }

        private async Task SendPrimaryGreeting(Chat chat)
        {
            await _botClient.SendTextMessageAsync(chat.Id, string.Format(_messageConfiguration.CurrentValue.Greetings, chat.FirstName), replyMarkup: GetStartKeyboard());
        }

        private ReplyKeyboardMarkup GetStartKeyboard()
        {
            ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
            {
                new KeyboardButton[] 
                { 
                    new KeyboardButton(_commandConfiguration.CurrentValue.Catalog), 
                    new KeyboardButton(_commandConfiguration.CurrentValue.Orders) 
                }
            });
            replyKeyboardMarkup.ResizeKeyboard = true;
            return replyKeyboardMarkup;
        }                  
    }
}
