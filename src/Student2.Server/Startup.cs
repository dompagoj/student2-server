using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Student2.DAL;
using Student2.Server.Extensions;

namespace Student2.Server
{
    public class Startup
    {
        IConfiguration Configuration { get; }
        IWebHostEnvironment Env { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            (Configuration, Env) = (configuration, env);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureSecrets(Configuration);
            services.AddDbContext<AppDbContext>(opts =>
                opts.UseNpgsql(Configuration.GetConnectionString("AppDbContext")));
            services.ConfigureIdentity();

            services.AddCors();
            services.AddControllers();
            services.ConfigureAuth(Configuration);
            services.ConfigureServices();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseCors(opts => opts.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
