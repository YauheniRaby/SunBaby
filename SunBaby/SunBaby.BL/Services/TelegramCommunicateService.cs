using Microsoft.Extensions.Options;
using SunBaby.BL.Configuration;
using SunBaby.BL.Services.Abstract;
using SunBaby.DA.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
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

        public async Task SpotCommand(Update update)
        {
            var config = _commandConfiguration.CurrentValue;
            
            if (update.Message != null)
            {
                switch (update.Message.Text)
                {
                    case var value when value == config.Start:
                        await SendPrimaryGreetingAndMainMenuAsync(update.Message.Chat);
                        break;
                    case var value when value == config.Orders:
                        break;
                    case var value when value == config.Catalog:
                        await SendCategoriesListAsync(update.Message.Chat.Id);
                        break;
                }
                return;
            }

            if (update.CallbackQuery != null)
            {
                var commandData = update.CallbackQuery.Data.Split(':');
                if(commandData.Length == 2)
                {
                    switch (commandData[0])
                    {
                        case var value when value == config.Category:
                            await SendToysByCategoriesAsync(update.CallbackQuery.From.Id, commandData[1]);
                            break;
                    }
                }                
            }
        }

        private async Task SendPrimaryGreetingAndMainMenuAsync(Chat chat)
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

            await _botClient.SendTextMessageAsync(chat.Id, string.Format(_messageConfiguration.CurrentValue.Greetings, chat.FirstName), replyMarkup: replyKeyboardMarkup);
        }        

        private async Task SendCategoriesListAsync(long userId)
        {
            var categoriesList = await _toyService.GetCategoriesListAsync();
            var inlineKeyboard = new InlineKeyboardMarkup(categoriesList.Select(x => new[] { InlineKeyboardButton.WithCallbackData(x, $"{_commandConfiguration.CurrentValue.Category}:{x}") }));

            await _botClient.SendTextMessageAsync(userId, _messageConfiguration.CurrentValue.SelectCategory, replyMarkup: inlineKeyboard);
        }

        private async Task SendToysByCategoriesAsync(long userId, string categoryName)
        {
            var categoriesList = await _toyService.GetToysByCategoryAsync(categoryName);
            categoriesList.ToList().ForEach(async x =>
            {
                var inlineKeyboard = new InlineKeyboardMarkup(new[] { InlineKeyboardButton.WithCallbackData(string.Format(_messageConfiguration.CurrentValue.NewOrder, x.Name), $"{_commandConfiguration.CurrentValue.NewOrder}:{x.Id}")});
                await _botClient.SendPhotoAsync(userId, x.ImageLink, GetProductPresentation(x), ParseMode.Html, replyMarkup: inlineKeyboard);
            });
        }

        private string GetProductPresentation(Toy toy)
        {
            return string.Format(
                _messageConfiguration.CurrentValue.ProductPresentation,
                toy.Type,
                toy.Name,
                Environment.NewLine,
                Environment.NewLine,
                toy.Description,
                Environment.NewLine,
                Environment.NewLine,
                Environment.NewLine,
                toy.Tarif1,
                Environment.NewLine,
                toy.Tarif2,
                Environment.NewLine,
                toy.Tarif3,
                Environment.NewLine,
                toy.Tarif4,
                Environment.NewLine,
                Environment.NewLine,
                toy.Link);
        }
    }
}
