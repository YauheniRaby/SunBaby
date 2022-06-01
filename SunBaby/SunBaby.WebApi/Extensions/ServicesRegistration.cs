using Microsoft.Extensions.DependencyInjection;
using SunBaby.BL.Services;
using SunBaby.BL.Services.Abstract;

namespace SunBaby.WebApi.Extensions
{
    public static class ServicesRegistration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<ITelegramCommunicateService, TelegramCommunicateService>();
            services.AddSingleton<IToyService, ToyService>();
            services.AddSingleton<IOrderService, OrderService>();
            services.AddSingleton<IUserService, UserService>();
        }
    }
}
