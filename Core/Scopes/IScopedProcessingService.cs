namespace DroneManagementSystem.Core.Scopes
{
    public interface IScopedProcessingService
    {
        Task CheckBatteryLevelsAsync(CancellationToken stoppingToken);
    }
}
