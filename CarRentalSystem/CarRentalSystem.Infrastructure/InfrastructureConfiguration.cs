using CarRentalSystem.Application.Contracts;
using CarRentalSystem.Infrastructure.Persistence;
using CarRentalSystem.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarRentalSystem.Infrastructure
{
    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
                            //Register DbContext
            return services.AddDbContext<CarRentalDbContext>(options => options
                               .UseSqlServer(
                                   configuration.GetConnectionString("DefaultConnection"),
                                   b => b.MigrationsAssembly(typeof(CarRentalDbContext).Assembly.FullName)))
                //Register db initializer
                .AddTransient<IInitializer, CarRentalDbInitializer>()
                //Register repository
                .AddTransient(typeof(IRepository<>), typeof(DataRepository<>));
        }
    }
}
