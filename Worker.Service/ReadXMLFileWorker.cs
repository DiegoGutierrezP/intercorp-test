using MediatR;
using Worker.Application.Features.Commands;

namespace Worker.Service
{
    public class ReadXMLFileWorker : BackgroundService
    {
        //private readonly ILogger<ReadXMLFileWorker> _logger;
        //private readonly IMediator _mediator;
        //public ReadXMLFileWorker(ILogger<ReadXMLFileWorker> logger, IMediator mediator)
        //{
        //    _logger = logger;
        //    _mediator = mediator;
        //}
        private readonly IServiceScopeFactory _scopeFactory;

        public ReadXMLFileWorker(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                //if (_logger.IsEnabled(LogLevel.Information))
                //{
                //    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                //    await _mediator.Send(new ReadXMLFileCommand());
                //}

                using (var scope = _scopeFactory.CreateScope())
                {
                    var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                    //var result = await mediator.Send(new ReadXMLFileCommand(), stoppingToken);

                    // Manejo adicional
                }


                await Task.Delay(TimeSpan.FromMinutes(2), stoppingToken);
            }
        }
    }
}
