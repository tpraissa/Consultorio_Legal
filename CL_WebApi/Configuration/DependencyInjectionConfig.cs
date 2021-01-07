using CL.Data.Repository;
using CL.Manager.Implementation;
using CL.Manager.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CL.WebApi.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            //Injeção de dependencia
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteManager, ClienteManager>();
        }
    }
}
