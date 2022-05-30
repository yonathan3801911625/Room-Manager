using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RoomManger.WebApi.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomManger.WebApi.Extensions
{
    public static class FeatureExtensions
    {
        /// <summary>
        /// Método estático que permite configurar las características generales como los CORS.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddFeature(this IServiceCollection services, IConfiguration configuration)
        {
            //Variables de clase
            string myPolice = "policeApi";

            //Se mapea la información de la sección config en el helper AppSettings para tener dicha info en memoria;
            var appSettingsSection = configuration.GetSection("Config");
            services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();

            //Se define la configuración para las peticiones de origenes cruzados.
            services.AddCors(options =>
            {
                options.AddPolicy(myPolice,
                    builder => builder.WithOrigins(appSettings.OriginCors)
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            // Método de extensión para la configuración del token.
            //services.AddAuthentication(appSettings);

            return services;
        }
    }
}
