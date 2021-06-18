using Application.Features.ClientFeatures.Commands;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateClientCommand, Client>();
            CreateMap<UpdateClientCommand, Client>();
        }
    }
}
