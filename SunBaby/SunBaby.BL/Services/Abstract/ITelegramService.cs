using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace SunBaby.BL.Services.Abstract
{
    public interface ITelegramService
    {
        Task<User> GetAboutMe();
    }
}
