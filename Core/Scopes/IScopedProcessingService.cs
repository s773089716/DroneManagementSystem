/**************************************************************************************************
 * Author   : Sampath Kumara
 * Date     : 2023-06-14
 *************************************************************************************************/
namespace DroneManagementSystem.Core.Scopes
{
    public interface IScopedProcessingService
    {
        Task CheckBatteryLevelsAsync(CancellationToken stoppingToken);
    }
}
