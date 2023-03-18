using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using LoginModel.Repositories;
using Student2.Server.Models;
using Student2.Server.Services;

namespace Student2.Server.Extensions
{
    public static class AppDependencies
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddSingleton<AppJwtTokenHandler>();
            // services.AddSingleton<GCloudStorage>();
            services.AddSingleton<MarkdownService>();

            services.AddScoped<AuthService>();
            services.AddScoped<PostRepository>();
            services.AddScoped<CourseRepository>();
            services.AddScoped<TutorRepository>();
        }

        public static void ConfigureSecrets(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<GCloudSettings>(configuration.GetSection("GCloud"));
        }
    }
}
