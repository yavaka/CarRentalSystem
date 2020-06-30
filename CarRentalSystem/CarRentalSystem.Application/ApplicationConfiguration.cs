using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CarRentalSystem.Application
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services,
            IConfiguration configuration)
        {
            return services.Configure<ApplicationSettings>(
                configuration.GetSection(nameof(ApplicationSettings)),
                options => options.BindNonPublicProperties = true)
                //configures MediatR
                .AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
