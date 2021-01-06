using AutoMapper;
using CL.Core.Domain;
using CL.Core.Shared.ModelViews;
using System;
using System.Collections.Generic;
using System.Text;

namespace CL.Manager.Mapping
{
    public class AlterarClienteMappingProfile : Profile
    {
        public AlterarClienteMappingProfile()
        {
            CreateMap<AlterarCliente, Cliente>()
                    .ForMember(d => d.UltimaAtualizacao, o => o.MapFrom(x => DateTime.Now))
                    .ForMember(d => d.DataNascimento, o => o.MapFrom(x => x.DataNascimento.Date)); //Tirar a hora na dataNascimento
        }
    }
    
}