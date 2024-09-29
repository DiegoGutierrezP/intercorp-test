using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Worker.Application.Features.Commands;

namespace Worker.Jobs.Functions
{
    public class ReadXmlFilesFunction
    {
        private readonly IMediator _mediator;
        public ReadXmlFilesFunction(IMediator mediator)
        {
            _mediator = mediator;
        }

        [FunctionName("ReadXmlFilesFunction")]
        public async Task Run([TimerTrigger("0 */1 * * * *")] TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            await _mediator.Send(new ReadXMLFileCommand());

        }
    }
}
