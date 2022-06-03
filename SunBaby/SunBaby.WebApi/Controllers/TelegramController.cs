using Microsoft.AspNetCore.Mvc;
using SunBaby.BL.Services.Abstract;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace SunBaby.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    public class TelegramController : ControllerBase
    {
        readonly ITelegramCommunicateService _telegramService;        

        public TelegramController(ITelegramCommunicateService telegramService)
        {
            _telegramService = telegramService;            
        }

        //[HttpGet("about_me")]
        //public async Task<ActionResult<User>> GetAboutMeAsync()
        //{
        //    return Ok(await _telegramService.GetAboutMeAsync());
        //}

        [HttpPost]
        [ApiExplorerSettings(IgnoreApi = true)]
        public void Post([FromBody] Update update)
        {
            _telegramService.SpotCommand(update);
        }
    }
}
