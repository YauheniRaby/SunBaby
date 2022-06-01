using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SunBaby.BL.Configuration;
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
        readonly IOptionsMonitor<CommandConfiguration> _commandConfiguration;
        readonly IToyService _toyService;

        public TelegramController(ITelegramCommunicateService telegramService, IOptionsMonitor<CommandConfiguration> commandConfiguration, IToyService toyService )
        {
            _telegramService = telegramService;
            _commandConfiguration = commandConfiguration;
            _toyService = toyService;
        }

        [HttpGet("about_me")]
        public async Task<ActionResult<User>> GetAboutMeAsync()
        {
            return Ok(await _telegramService.GetAboutMeAsync());
        }

        [HttpPost]
        [ApiExplorerSettings(IgnoreApi = true)]
        public void Post([FromBody] Update update)
        {
            _telegramService.SpotCommand(update.Message);
        }

        [HttpGet("test")]
        public ActionResult TestAsync()
        {
            _toyService.AddToy();
            return Ok();
        }
    }
}
