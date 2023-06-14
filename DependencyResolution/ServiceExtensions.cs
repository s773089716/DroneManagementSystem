using DroneManagementSystem.Core.Repositories;
using DroneManagementSystem.Core.Scopes;
using DroneManagementSystem.Core.Services;
using DroneManagementSystem.Repositories.InMemoryRepositories;
using DroneManagementSystem.Scopes;
using DroneManagementSystem.Services;

namespace DroneManagementSystem.DependencyResolution
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, ILoggerFactory _loggerFactory)
        {
            services.AddScoped<IDroneRepository, DroneRepository>();
            services.AddScoped<IDispatchService, DispatchService>();            
            services.AddScoped<IScopedProcessingService, DefaultScopedProcessingService>();

            return services;
        }
    }
}
