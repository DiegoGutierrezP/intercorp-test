using AutoMapper;
using EventBus.Messages;
using MassTransit;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Worker.Application.Dtos;
using Worker.Application.Interfaces;
using Worker.Domain.Entities;

namespace Worker.Application.Features.Commands
{
    public class ReadXMLFileCommandHandler : IRequestHandler<ReadXMLFileCommand, string>
    {
        private readonly IFileInformationRepository _fileInformationRepository;
        private readonly IRequestClient<ServiceOneMessage> _clientService1;
        private readonly IRequestClient<ServiceTwoMessage> _clientService2;
        private readonly IMapper _mapper;
        public ReadXMLFileCommandHandler(
            IFileInformationRepository fileInformationRepository,
            IRequestClient<ServiceOneMessage> clientService1,
            IRequestClient<ServiceTwoMessage> clientService2,
            IMapper mapper
            )
        {
            _fileInformationRepository = fileInformationRepository;
            _clientService1 = clientService1;
            _clientService2 = clientService2;
            _mapper = mapper;
        }

        public async Task<string> Handle(ReadXMLFileCommand request, CancellationToken cancellationToken)
        {
            var lastActivity = await this._fileInformationRepository.GetLastFile();

            int fileNumber = 0;
            if (lastActivity != null)
            {
                fileNumber = lastActivity.FileNumber + 1;
            }

            //5 by 5 process
            for (int i = fileNumber; i < (fileNumber + 5); i++)
            {
                string fileName = $"myXMLFile{i}.xml";
                var filePath = Path.Combine("XML-Example", fileName);

                if (File.Exists(filePath))
                {
                    try
                    {
                        var xmlContent = await File.ReadAllTextAsync(filePath);
                        var xmlDocument = XDocument.Parse(xmlContent);
                        string jsonResult = JsonConvert.SerializeXNode(xmlDocument, Newtonsoft.Json.Formatting.Indented, true);


                        //TODO:
                        var transactObject = JsonConvert.DeserializeObject<XMLFileDto>(jsonResult);

                        var message = _mapper.Map<FileInformationMessage>(transactObject);

                        var response01 = await _clientService1.GetResponse<FileInformationMessage>(message);

                        var response02 = await _clientService2.GetResponse<FileInformationMessage>(response01.Message);

                        var entityFileInfo = _mapper.Map<FileInformation>(response02.Message);
                        entityFileInfo.FileName = fileName;
                       entityFileInfo.FileNumber = i;
                        entityFileInfo.CreatedAt = DateTime.UtcNow;
                        entityFileInfo.UpdatedAt = DateTime.UtcNow;

                        await this._fileInformationRepository.AddEntity(entityFileInfo);
                        await this._fileInformationRepository.SaveAsync();
                    }
                    catch (Exception ex)
                    {
                        Console.Write(ex.Message);
                        continue;
                    }

                }

            }

            return string.Empty;
        }
    }
}
