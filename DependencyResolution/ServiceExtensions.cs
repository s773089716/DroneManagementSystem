using DroneManagementSystem.Core.Repositories;
using DroneManagementSystem.Core.Services;
using DroneManagementSystem.Repositories.InMemoryRepositories;
using DroneManagementSystem.Services;

namespace DroneManagementSystem.DependencyResolution
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, ILoggerFactory _loggerFactory)
        {
            services.AddScoped<IDroneRepository, DroneRepository>();
            services.AddScoped<IDispatchService, DispatchService>();

            return services;
        }
    }
}
