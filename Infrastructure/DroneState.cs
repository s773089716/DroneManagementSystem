/**************************************************************************************************
 * Author   : Sampath Kumara
 * Date     : 2023-05-24
 *************************************************************************************************/
namespace DroneManagementSystem.Infrastructure
{
    public enum DroneState
    {
        UNIDENTIFIED = 0,
        IDLE, 
        LOADING, 
        LOADED, 
        DELIVERING, 
        DELIVERED, 
        RETURNING
    }
}
