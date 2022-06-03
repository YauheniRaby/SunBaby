using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace SunBaby.BL.Services.Abstract
{
    public interface ITelegramCommunicateService
    {
        Task SpotCommand(Update update);
    }
}
