using MediatR;
using Worker.Application.Features.Commands;

namespace Worker.Service
{
    public class ReadXMLFileWorker : BackgroundService
    {
       
        private readonly IServiceScopeFactory _scopeFactory;

        public ReadXMLFileWorker(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                
                using (var scope = _scopeFactory.CreateScope())
                {
                    var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                    var result = await mediator.Send(new ReadXMLFileCommand(), stoppingToken);

                }

                await Task.Delay(TimeSpan.FromMinutes(2), stoppingToken);
            }
        }
    }
}
