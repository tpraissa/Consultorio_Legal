using AutoMapper;
using CL.Manager.Mapping;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CL.WebApi.Configuration
{
    public static class AutoMappingConfig
    {
        public static void AddAutoMappingConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(NovoClienteMappingProfile), typeof(AlterarClienteMappingProfile));
        }
    }
}
