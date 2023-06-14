using DroneManagementSystem.DTOs;
using System.Threading.Tasks;

namespace DroneManagementSystem.Core.Services
{
    public interface IStemService : IServiceBase
    {
        Task<DronesListResponse> GetAvailableDrones(DronesListRequest request);
    }
}
