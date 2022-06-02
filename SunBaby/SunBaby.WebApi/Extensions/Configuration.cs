using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SunBaby.BL.Configuration;
using SunBaby.DA.Configuration;

namespace SunBaby.WebApi.Extensions
{
    public static class Configuration
    {
        public static void FillConfiguration(this IServiceCollection services, IConfiguration Configuration)
        {
            services.Configure<MessageConfiguration>(Configuration.GetSection(nameof(MessageConfiguration)));
            services.Configure<CommandConfiguration>(Configuration.GetSection(nameof(CommandConfiguration)));
            services.Configure<MongoSettings>(Configuration.GetSection(nameof(MongoSettings)));
            services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
        }
    }
}
