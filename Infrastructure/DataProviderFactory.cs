/**************************************************************************************************
 * Author   : Sampath Kumara
 * Date     : 2023-05-24
 *************************************************************************************************/
using DroneManagementSystem.Core.Infrastructure;

namespace DroneManagementSystem.Infrastructure
{
    public class DataProviderFactory
    {
        #region Public Methods --------------------------------------------------------------------
        /// <summary>
        /// Provides different data providers according to the requirement
        /// </summary>
        /// <returns>IDataProvider</returns>
        public static IDataProvider GetDataProvider()
        {
            return new InMemoryDataProvider();
        }
        #endregion
    }
}