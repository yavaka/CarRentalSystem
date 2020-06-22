using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalSystem.Web
{
    public static class WebConfiguration
    {
        public static IServiceCollection AddWebComponents(this IServiceCollection services) 
        {
            services.AddControllers()
                .AddNewtonsoftJson();

            return services;
        }
    }
}
