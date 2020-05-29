using Microsoft.Extensions.DependencyInjection;
using Student2.Server.Repositories;

namespace Student2.Server.Extensions
{
    public static class AppDependencies
    {
        public static void ConfigureSingletons(this IServiceCollection services)
        {
            services.AddSingleton<AppJwtTokenHandler>();
        }
    }
}
