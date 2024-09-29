using AutoMapper;
using EventBus.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worker.Application.Dtos;
using Worker.Domain.Entities;

namespace Worker.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<XMLFileDto, FileInformationMessage>()
                .ForMember(dest => dest.Person, conf => conf.MapFrom(s => JsonConvert.SerializeObject(s.Person)))
                .ReverseMap();

            CreateMap<FileInformationMessage, FileInformation>()
                .ForMember(dest => dest.Person, conf => conf.MapFrom(s => JsonConvert.SerializeObject(s.Person)))
                .ForMember(dest => dest.Elt, conf => conf.MapFrom(s => JsonConvert.SerializeObject(s.Elt)))
                .ReverseMap();
        }
    }
}
