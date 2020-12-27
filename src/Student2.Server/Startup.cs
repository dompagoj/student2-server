using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StackExchange.Redis;
using Student2.DAL;
using Student2.Server.Extensions;
using Student2.Server.SignalRHubs;

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

            services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect("localhost"));

            services.AddCors();
            services.AddControllers();
            services.AddSignalR().AddStackExchangeRedis("localhost");
            services.ConfigureAuth(Configuration);
            services.ConfigureServices();

            if (Env.IsDevelopment())
            {
                services.AddSwaggerGen();
            }
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Student2 Api v1"));
            }

            app.UseCors(opts => opts.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ChatHub>("/chat");
            });
        }
    }
}
