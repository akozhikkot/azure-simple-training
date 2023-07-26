using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace TodoApi.Messaging
{
    public class MessageSender
    {
        private readonly IConfiguration _configuration;
        public MessageSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task Send<T>(T message)
        {
            var serviceBusConnectionString = _configuration.GetConnectionString("MessageBus");
            var queueName = _configuration.GetValue<string>("TodoQueue");
            var client = new ServiceBusClient(serviceBusConnectionString);
            var sender = client.CreateSender(queueName);
            var messages = new ServiceBusMessage[]
            { new ServiceBusMessage(JsonSerializer.Serialize(message)) };
            await sender.SendMessagesAsync(messages);
        }
    }
}
