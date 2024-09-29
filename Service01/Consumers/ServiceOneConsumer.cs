using EventBus.Messages;
using MassTransit;

namespace Service01.Consumers
{
    public class ServiceOneConsumer : IConsumer<ServiceOneMessage>
    {
        public async Task Consume(ConsumeContext<ServiceOneMessage> context)
        {
            ServiceOneMessage message = context.Message;
            message.LastUpdated = $"MICROSERVICES_PROCESS_01_<<{DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm")}>>";
        
            await context.RespondAsync(message);
        }
    }
}
