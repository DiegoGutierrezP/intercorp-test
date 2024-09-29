using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worker.Application.Features.Commands
{
    public record ReadXMLFileCommand()
        : IRequest<string>;
}
