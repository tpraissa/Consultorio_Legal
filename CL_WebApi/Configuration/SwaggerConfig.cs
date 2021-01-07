using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CL.WebApi.Configuration
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            //iniciando o swagger como serviço de documentação
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", 
                    new OpenApiInfo 
                    { 
                        Title = "Consultorio Legal", 
                        Version = "v1" ,
                        Description = "aprendendo usar .net core em aplicaçao real pelas aulas de Francis Silveira",
                        Contact = new OpenApiContact
                        {
                            Name = "Raíssa T.",
                            Email = "raa.suka@gmail.com"
                        }
                    });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                xmlPath = Path.Combine(AppContext.BaseDirectory, "CL.Core.Shared.xml");
                c.IncludeXmlComments(xmlPath);
            });
        }

        public static void UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            //configurar para a aplicaçao usar
            app.UseSwagger();
            //Endpoint ligado ao swagger Doc = v1
            app.UseSwaggerUI(c => {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("./swagger/v1/swagger.json", "CL V1");
            });
        }
    }
}
