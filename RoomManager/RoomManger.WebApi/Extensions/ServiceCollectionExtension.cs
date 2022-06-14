using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using RoomManager.Aplicacion.Interfaz;
using RoomManager.Aplicacion.Principal;
using RoomManager.Dominio.Core.General;
using RoomManager.Dominio.Interfaz.General;
using RoomManager.Dominio.InterfazRepositorio.General;
using RoomManager.Infraestructura.Datos;
using RoomManager.Infraestructura.Interfaz.General;
using RoomManager.Infraestructura.Repositorio.General;
using RoomManager.Infraestructura.Repositorio.UnidadDeTrabajo;
using RoomManager.Transversal.Comun.Conexion;
using RoomManager.Transversal.Comun.Log;
using RoomManager.Transversal.Comun.UnidadDeTrabajo;
using RoomManager.Transversal.Comun.Utilidades;
using RoomManager.Transversal.Logging;
using RoomManager.Transversal.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RoomManger.WebApi.Extensions
{
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// Método estático que permite hacer la inyección de dependencias entre capas.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            //Inyección de la conexión a base de datos.
            services.AddSingleton <IConnectionRoomManagerDB, ConnectionRoomManagerFactory>();

            //UnidadDeTrabajo
            services.AddScoped<IUnidadDeTrabajo, UnidadDeTrabajo>();

            //Inyección para log.
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

            //Inyección para util.
            services.AddScoped<IUtil, Util>();

            services.AddScoped<IUsuarioAplicacion, UsuarioAplicacion>();
            services.AddScoped<IUsuarioDominio, UsuarioDominio>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

            return services;
        }// Fín método.

        /// <summary>
        /// Método estático que permite definir la configuración de swagger.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="xmlFileName"></param>
        /// <returns></returns>
        public static IServiceCollection AddSwagger(this IServiceCollection services, string xmlFileName)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Brothers Technology Services API Market",
                    Description = "Web API Room Manager",
                    TermsOfService = new Uri("https://EmEmpleados.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Admin",
                        Email = "admin@emergiacc.com",
                        Url = new Uri("https://EmEmpleados.com/contact")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://EmEmpleados.com/license")
                    }
                });
                // Set the comments path for the Swagger JSON and UI.
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
                c.IncludeXmlComments(xmlPath);

                //Configuración de autorización por token.               
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Authorization by API key. Set tokent example(Bearer + token)",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Name = "Authorization"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id   = "Bearer"
                            }
                        },
                        new string[]{ }
                    }
                });
            });

            return services;

        }// Fín método.
    }
}
