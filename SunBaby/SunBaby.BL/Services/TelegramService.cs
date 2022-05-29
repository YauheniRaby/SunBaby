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

        public Task<User> GetAboutMe()
        {
            return _botClient.GetMeAsync();            
        }
    }
}
