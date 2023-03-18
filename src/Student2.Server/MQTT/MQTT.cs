using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Extensions.ManagedClient;
using Student2.Server.Models;

namespace Student2.Server.MQTT;

public static class MQTTExtensions
{
    public static void AddMQTT(this IServiceCollection services)
    {
        var factory = new MqttFactory();

        services.AddSingleton<IManagedMqttClient>(provider =>
        {
            var settings = provider.GetRequiredService<IConfiguration>().GetRequiredSection("MQTT")
                .Get<MQTTSettings>()!;

            var client = factory.CreateManagedMqttClient();
            var opts = new MqttClientOptionsBuilder()
                .WithTcpServer(settings.Host)
                .WithCredentials(settings.Username, settings.Password);

            var managedClientOpts = new ManagedMqttClientOptionsBuilder()
                .WithClientOptions(opts)
                .Build();

            client.StartAsync(managedClientOpts).Wait();
            return client;
        });
    }
}
