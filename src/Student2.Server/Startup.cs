using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StackExchange.Redis;
using LoginModel;
using Student2.Server.Extensions;
using Student2.Server.MQTT;
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
            services.AddControllers()
                .AddJsonOptions(opts =>
                {
                    opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });
            services.AddSignalR().AddStackExchangeRedis("localhost");
            services.ConfigureAuth(Configuration);
            services.AddCustomServices();

            services.AddMQTT();

            if (Env.IsDevelopment())
            {
                // TODO
                services.AddSwaggerGen(opts =>
                {
                    opts.SupportNonNullableReferenceTypes();
                });
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
