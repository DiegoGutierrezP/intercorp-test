using EventBus.Messages;
using MassTransit;
using System;

namespace Service02.Consumers
{

    public class ServiceTwoConsumer : IConsumer<ServiceTwoMessage>
    {
        public async Task Consume(ConsumeContext<ServiceTwoMessage> context)
        {
            ServiceTwoMessage message = context.Message;

            message.RegEx = RandomString(7);
            message.LastModified = $"MICROSERVICES_PROCESS_02_<<{DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm")}>>";

            await context.RespondAsync(message);
        }

        private string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
