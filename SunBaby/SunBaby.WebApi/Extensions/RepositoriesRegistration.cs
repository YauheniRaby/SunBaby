using Microsoft.Extensions.DependencyInjection;
using SunBaby.DA.Repositories;
using SunBaby.DA.Repositories.Abstract;

namespace SunBaby.WebApi.Extensions
{
    public static class RepositoriesRegistration
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IToyRepository, ToyRepository>();
        }
    }
}
