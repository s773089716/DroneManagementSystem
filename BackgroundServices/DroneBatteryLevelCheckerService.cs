using DroneManagementSystem.Core.Scopes;
using DroneManagementSystem.Core.Services;
using DroneManagementSystem.DTOs;
using DroneManagementSystem.Models;
using DroneManagementSystem.Services;

namespace DroneManagementSystem.BackgroundServices
{
    public class DroneBatteryLevelCheckerService : BackgroundService
    {                
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<DroneBatteryLevelCheckerService> _logger;

        public DroneBatteryLevelCheckerService(IServiceProvider serviceProvider, ILogger<DroneBatteryLevelCheckerService> logger)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"{nameof(DroneBatteryLevelCheckerService)} is running.");

            await DoWorkAsync(stoppingToken);
        }

        private async Task DoWorkAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"{nameof(DroneBatteryLevelCheckerService)} is working.");

            using (IServiceScope scope = _serviceProvider.CreateScope())
            {
                IScopedProcessingService scopedProcessingService = scope.ServiceProvider.GetRequiredService<IScopedProcessingService>();

                await scopedProcessingService.CheckBatteryLevelsAsync(stoppingToken);
            }
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"{nameof(DroneBatteryLevelCheckerService)} is stopping.");

            await base.StopAsync(stoppingToken);
        }
    }
}
