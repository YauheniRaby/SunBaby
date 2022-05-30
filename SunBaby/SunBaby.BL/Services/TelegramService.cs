using SunBaby.BL.Services.Abstract;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace SunBaby.BL.Services
{
    public class TelegramService : ITelegramService
    {
        ITelegramBotClient _botClient;
        
        public TelegramService(ITelegramBotClient botClient)
        {
            _botClient = botClient;
        }

        public Task<User> GetAboutMeAsync()
        {
            return _botClient.GetMeAsync();            
        }
    }
}
