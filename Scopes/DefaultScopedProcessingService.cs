using DroneManagementSystem.Core.Scopes;
using DroneManagementSystem.Core.Services;
using DroneManagementSystem.DTOs;
using DroneManagementSystem.Models;
using System.Text;

namespace DroneManagementSystem.Scopes
{
    public class DefaultScopedProcessingService : IScopedProcessingService
    {
        private const int ProcesDelay = 5 * 1000; // Need to be included in settings

        private readonly ILogger<DefaultScopedProcessingService> _logger;
        private IDispatchService _dispatchService;

        public DefaultScopedProcessingService(IDispatchService dispatchService, ILogger<DefaultScopedProcessingService> logger)
        {
            _logger = logger;
            _dispatchService = dispatchService;
        }        

        public async Task CheckBatteryLevelsAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                StringBuilder output = new StringBuilder();
                output.Append("\r\nCheck Drone Battery Levels");
                output.Append("\r\n==========================");                

                DronesListResponse dronesListResponse = await _dispatchService.GetDronesList(new DronesListRequest { });
                foreach (Drone drone in dronesListResponse.Drones)
                {                    
                    output.Append($"\r\nDrone: {drone.SerialNumber} => Battery Level: {drone.BatteryCapacity}");
                }

                _logger.LogInformation($"{output.ToString()}\r\n");

                await Task.Delay(ProcesDelay, stoppingToken);
            }
        }
    }
}
